using Olm.Service.DTOs.Lessons;

namespace Olm.Service.Interfaces;

public interface ILessonService
{
    Task<LessonResultDto> AddAsync(LessonCreationDto dto);
    Task<LessonResultDto> UpdateAsync(LessonUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<LessonResultDto>> GetAllAsync();
    Task<LessonResultDto> GetByIdAsync(long id);
}
