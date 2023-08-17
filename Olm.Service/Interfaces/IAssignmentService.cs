using Olm.Service.DTOs.Assigments;

namespace Olm.Service.Interfaces;

public interface IAssignmentService
{
    Task<AssignmentResultDto> AddAsync(AssignmentCreationDto dto);
    Task<AssignmentResultDto> UpdateAsync(AssignmentUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<AssignmentResultDto>> GetAllAsync();
    Task<AssignmentResultDto?> GetByIdAsync(long id);
}
