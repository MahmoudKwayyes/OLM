using AutoMapper;
using Olm.Data.IRepostiries;
using Olm.Service.Interfaces;
using Olm.Service.Exceptions;
using Olm.Domain.Entities.Quizzes;
using Olm.Service.DTOs.Quizzes;

namespace Olm.Service.Services;

public class AnswerService : IAnswerService
{
    private readonly IMapper mapper;
    private readonly IRepository<Answer> repository;
    public AnswerService(IRepository<Answer> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<AnswerResultDto> AddAsync(AnswerCreationDto dto)
    {
        var existAnswer = await this.repository.GetAsync(c => c.Title.Equals(dto.Title));
        if (existAnswer is not null)
            throw new AlreadyExistException("This Answer is already exist");

        var mapped = this.mapper.Map<Answer>(dto);
        await this.repository.CreateAsync(mapped);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<AnswerResultDto>(mapped);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var delAnswer = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Answer is not found with id: {id}");

        this.repository.Delete(delAnswer);
        await repository.SaveAsync();
        return true;
    }

    public async Task<AnswerResultDto> UpdateAsync(AnswerUpdateDto dto)
    {
        var Answer = await this.repository.GetAsync(c => c.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This Answer is not found with id: {dto.Id}");

        var mappedAnswer = mapper.Map(dto, Answer);
        this.repository.Update(mappedAnswer);
        await this.repository.SaveAsync();

        var result = mapper.Map<AnswerResultDto>(mappedAnswer);
        return result;
    }

    public async Task<AnswerResultDto?> GetByIdAsync(long id)
    {
        var Answer = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Answer is not found with id: {id}");

        var result = mapper.Map<AnswerResultDto>(Answer);
        return result;
    }

    public async Task<IEnumerable<AnswerResultDto>> GetAllAsync()
    {
        var Answers = this.repository.GetAll();
        var results = new List<AnswerResultDto>();
        if (Answers is not null)
            foreach (var Answer in Answers)
            {
                var mapped = mapper.Map<AnswerResultDto>(Answer);
                results.Add(mapped);
            }
        return results;
    }
}
