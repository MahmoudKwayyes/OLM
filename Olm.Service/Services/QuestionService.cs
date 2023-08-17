using AutoMapper;
using Olm.Data.IRepostiries;
using Olm.Service.Interfaces;
using Olm.Service.Exceptions;
using Olm.Domain.Entities.Quizzes;
using Olm.Service.DTOs.Quizzes;

namespace Olm.Service.Services;

public class QuestionService : IQuestionService
{
    private readonly IMapper mapper;
    private readonly IRepository<Question> repository;
    public QuestionService(IRepository<Question> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<QuestionResultDto> AddAsync(QuestionCreationDto dto)
    {
        var existQuestion = await this.repository.GetAsync(c => c.Title.Equals(dto.Title));
        if (existQuestion is not null)
            throw new AlreadyExistException("This Question is already exist");

        var mapped = this.mapper.Map<Question>(dto);
        await this.repository.CreateAsync(mapped);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<QuestionResultDto>(mapped);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var delQuestion = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Question is not found with id: {id}");

        this.repository.Delete(delQuestion);
        await repository.SaveAsync();
        return true;
    }

    public async Task<QuestionResultDto> UpdateAsync(QuestionUpdateDto dto)
    {
        var Question = await this.repository.GetAsync(c => c.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This Question is not found with id: {dto.Id}");

        var mappedQuestion = mapper.Map(dto, Question);
        this.repository.Update(mappedQuestion);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuestionResultDto>(mappedQuestion);
        return result;
    }

    public async Task<QuestionResultDto?> GetByIdAsync(long id)
    {
        var Question = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Question is not found with id: {id}");

        var result = mapper.Map<QuestionResultDto>(Question);
        return result;
    }

    public async Task<IEnumerable<QuestionResultDto>> GetAllAsync()
    {
        var Questions = this.repository.GetAll();
        var results = new List<QuestionResultDto>();
        if (Questions is not null)
            foreach (var Question in Questions)
            {
                var mapped = mapper.Map<QuestionResultDto>(Question);
                results.Add(mapped);
            }
        return results;
    }
}