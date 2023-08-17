using Olm.Service.DTOs.UserEnrollments;

namespace Olm.Service.Interfaces;

public interface IUserEnrollmentService
{
    Task<UserEnrollmentResultDto> AddAsync(UserEnrollmentCreationDto dto);
    Task<UserEnrollmentResultDto> UpdateAsync(UserEnrollmentUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<UserEnrollmentResultDto>> GetAllAsync();
    Task<UserEnrollmentResultDto?> GetByIdAsync(long id);
}
