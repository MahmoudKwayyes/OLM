using AutoMapper;
using Olm.Data.IRepostiries;
using Olm.Service.Interfaces;
using Olm.Service.Exceptions;
using Olm.Service.DTOs.UserEnrollments;
using Olm.Domain.Entities.UserEnrollments;

namespace Olm.Service.Services;

public class UserEnrollmentService : IUserEnrollmentService
{
    private readonly IMapper mapper;
    private readonly IRepository<UserEnrollment> repository;
    public UserEnrollmentService(IRepository<UserEnrollment> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<UserEnrollmentResultDto> AddAsync(UserEnrollmentCreationDto dto)
    {
        var existUserEnrollment = await this.repository.GetAsync(c => c.Phone.Equals(dto.Phone));
        if (existUserEnrollment is not null)
            throw new AlreadyExistException("This UserEnrollment is already exist");

        var mapped = this.mapper.Map<UserEnrollment>(dto);
        await this.repository.CreateAsync(mapped);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<UserEnrollmentResultDto>(mapped);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var delUserEnrollment = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This UserEnrollment is not found with id: {id}");

        this.repository.Delete(delUserEnrollment);
        await repository.SaveAsync();
        return true;
    }

    public async Task<UserEnrollmentResultDto> UpdateAsync(UserEnrollmentUpdateDto dto)
    {
        var UserEnrollment = await this.repository.GetAsync(c => c.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This UserEnrollment is not found with id: {dto.Id}");

        var mappedUserEnrollment = mapper.Map(dto, UserEnrollment);
        this.repository.Update(mappedUserEnrollment);
        await this.repository.SaveAsync();

        var result = mapper.Map<UserEnrollmentResultDto>(mappedUserEnrollment);
        return result;
    }

    public async Task<UserEnrollmentResultDto?> GetByIdAsync(long id)
    {
        var UserEnrollment = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This UserEnrollment is not found with id: {id}");

        var result = mapper.Map<UserEnrollmentResultDto>(UserEnrollment);
        return result;
    }

    public async Task<IEnumerable<UserEnrollmentResultDto>> GetAllAsync()
    {
        var UserEnrollments = this.repository.GetAll();
        var results = new List<UserEnrollmentResultDto>();
        if (UserEnrollments is not null)
            foreach (var UserEnrollment in UserEnrollments)
            {
                var mapped = mapper.Map<UserEnrollmentResultDto>(UserEnrollment);
                results.Add(mapped);
            }
        return results;
    }
}
