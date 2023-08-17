using AutoMapper;
using Olm.Data.IRepostiries;
using Olm.Service.Interfaces;
using Olm.Service.DTOs.Lessons;
using Olm.Domain.Entities.Lessons;
using Olm.Service.Exceptions;

namespace Olm.Service.Services;

public class LessonService : ILessonService
{
    private readonly IMapper mapper;
    private readonly IRepository<Lesson> repository;
    public LessonService(IRepository<Lesson> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<LessonResultDto> AddAsync(LessonCreationDto dto)
    {
        var existLesson = await this.repository.GetAsync(c => c.Title.Equals(dto.Title));
        if (existLesson is not null)
            throw new AlreadyExistException("This Lesson is already exist");

        var mapped = this.mapper.Map<Lesson>(dto);
        await this.repository.CreateAsync(mapped);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<LessonResultDto>(mapped);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var delLesson = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Lesson is not found with id: {id}");

        this.repository.Delete(delLesson);
        await repository.SaveAsync();
        return true;
    }

    public async Task<LessonResultDto> UpdateAsync(LessonUpdateDto dto)
    {
        var Lesson = await this.repository.GetAsync(c => c.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This Lesson is not found with id: {dto.Id}");

        var mappedLesson = mapper.Map(dto, Lesson);
        this.repository.Update(mappedLesson);
        await this.repository.SaveAsync();

        var result = mapper.Map<LessonResultDto>(mappedLesson);
        return result;
    }

    public async Task<LessonResultDto?> GetByIdAsync(long id)
    {
        var Lesson = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Lesson is not found with id: {id}");

        var result = mapper.Map<LessonResultDto>(Lesson);
        return result;
    }

    public async Task<IEnumerable<LessonResultDto>> GetAllAsync()
    {
        var Lessons = this.repository.GetAll();
        var results = new List<LessonResultDto>();
        if (Lessons is not null)
            foreach (var Lesson in Lessons)
            {
                var mapped = mapper.Map<LessonResultDto>(Lesson);
                results.Add(mapped);
            }
        return results;
    }
}
