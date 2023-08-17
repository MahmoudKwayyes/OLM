using Olm.Service.DTOs.ProgressTrackings;

namespace Olm.Service.Interfaces;

public interface IProgressTrackingService
{
    Task<ProgressTrackingResultDto> AddAsync(ProgressTrackingCreationDto dto);
    Task<ProgressTrackingResultDto> UpdateAsync(ProgressTrackingUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<ProgressTrackingResultDto>> GetAllAsync();
    Task<ProgressTrackingResultDto?> GetByIdAsync(long id);
}
