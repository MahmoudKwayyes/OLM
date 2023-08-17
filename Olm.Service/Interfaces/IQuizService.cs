using Olm.Service.DTOs.Quizzes;

namespace Olm.Service.Interfaces;

public interface IQuizService
{
    Task<QuizResultDto> AddAsync(QuizCreationDto dto);
    Task<QuizResultDto> UpdateAsync(QuizUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<QuizResultDto>> GetAllAsync();
    Task<QuizResultDto?> GetByIdAsync(long id);
}
