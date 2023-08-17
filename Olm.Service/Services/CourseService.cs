using AutoMapper;
using Olm.Data.IRepostiries;
using Olm.Service.Interfaces;
using Olm.Service.DTOs.Courses;
using Olm.Domain.Entities.Courses;
using Olm.Service.Exceptions;

namespace Olm.Service.Services;

public class CourseService : ICourseService
{
    private readonly IMapper mapper;
    private readonly IRepository<Course> repository;
    public CourseService(IRepository<Course> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<CourseResultDto> AddAsync(CourseCreationDto dto)
    {
        var existCourse = await this.repository.GetAsync(c => c.Name.Equals(dto.Name));
        if (existCourse is not null)
            throw new AlreadyExistException("This course is already exist");

        var mapped=this.mapper.Map<Course>(dto);
        await this.repository.CreateAsync(mapped);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<CourseResultDto>(mapped);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var delCourse=await this.repository.GetAsync(c=>c.Id.Equals(id))
          ??  throw new NotFoundException($"This course is not found with id: {id}");

        this.repository.Delete(delCourse);
        await repository.SaveAsync();
        return true;
    }

    public async Task<CourseResultDto> UpdateAsync(CourseUpdateDto dto)
    {
        var course = await this.repository.GetAsync(c => c.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This course is not found with id: {dto.Id}");

        var mappedCourse = mapper.Map(dto, course);
        this.repository.Update(mappedCourse);
        await this.repository.SaveAsync();

        var result= mapper.Map<CourseResultDto>(mappedCourse);
        return result;
    }

    public async Task<CourseResultDto?> GetByIdAsync(long id)
    {
        var course = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This course is not found with id: {id}");

        var result = mapper.Map<CourseResultDto>(course);
        return result;
    }

    public async Task<IEnumerable<CourseResultDto>> GetAllAsync()
    {
        var courses = this.repository.GetAll();
        var results = new List<CourseResultDto>();
        if (courses is not null)
            foreach (var course in courses) 
            {
                var mapped= mapper.Map<CourseResultDto>(course);
                results.Add(mapped);
            }
        return results;
    }
}
