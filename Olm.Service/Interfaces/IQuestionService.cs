using Olm.Service.DTOs.Quizzes;

namespace Olm.Service.Interfaces;

public interface IQuestionService
{
    Task<QuestionResultDto> AddAsync(QuestionCreationDto dto);
    Task<QuestionResultDto> UpdateAsync(QuestionUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<QuestionResultDto>> GetAllAsync();
    Task<QuestionResultDto?> GetByIdAsync(long id);
}
