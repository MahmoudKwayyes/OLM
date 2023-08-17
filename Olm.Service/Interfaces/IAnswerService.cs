using Olm.Service.DTOs.Quizzes;

namespace Olm.Service.Interfaces;

public interface IAnswerService
{
    Task<AnswerResultDto> AddAsync(AnswerCreationDto dto);
    Task<AnswerResultDto> UpdateAsync(AnswerUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<AnswerResultDto>> GetAllAsync();
    Task<AnswerResultDto?> GetByIdAsync(long id);
}
