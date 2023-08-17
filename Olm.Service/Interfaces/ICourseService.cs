using Olm.Service.DTOs.Courses;

namespace Olm.Service.Interfaces;

public interface ICourseService
{
    Task<CourseResultDto> AddAsync(CourseCreationDto dto);
    Task<CourseResultDto> UpdateAsync(CourseUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<CourseResultDto>> GetAllAsync();
    Task<CourseResultDto?> GetByIdAsync(long id);
}