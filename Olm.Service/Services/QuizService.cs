using AutoMapper;
using Olm.Data.IRepostiries;
using Olm.Service.Interfaces;
using Olm.Service.Exceptions;
using Olm.Domain.Entities.Quizzes;
using Olm.Service.DTOs.Quizzes;

namespace Olm.Service.Services;

public class QuizService : IQuizService
{
    private readonly IMapper mapper;
    private readonly IRepository<Quiz> repository;
    public QuizService(IRepository<Quiz> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<QuizResultDto> AddAsync(QuizCreationDto dto)
    {
        var existQuiz = await this.repository.GetAsync(c => c.Title.Equals(dto.Title));
        if (existQuiz is not null)
            throw new AlreadyExistException("This Quiz is already exist");

        var mapped = this.mapper.Map<Quiz>(dto);
        await this.repository.CreateAsync(mapped);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<QuizResultDto>(mapped);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var delQuiz = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Quiz is not found with id: {id}");

        this.repository.Delete(delQuiz);
        await repository.SaveAsync();
        return true;
    }

    public async Task<QuizResultDto> UpdateAsync(QuizUpdateDto dto)
    {
        var Quiz = await this.repository.GetAsync(c => c.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This Quiz is not found with id: {dto.Id}");

        var mappedQuiz = mapper.Map(dto, Quiz);
        this.repository.Update(mappedQuiz);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuizResultDto>(mappedQuiz);
        return result;
    }

    public async Task<QuizResultDto?> GetByIdAsync(long id)
    {
        var Quiz = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Quiz is not found with id: {id}");

        var result = mapper.Map<QuizResultDto>(Quiz);
        return result;
    }

    public async Task<IEnumerable<QuizResultDto>> GetAllAsync()
    {
        var Quizs = this.repository.GetAll();
        var results = new List<QuizResultDto>();
        if (Quizs is not null)
            foreach (var Quiz in Quizs)
            {
                var mapped = mapper.Map<QuizResultDto>(Quiz);
                results.Add(mapped);
            }
        return results;
    }
}