using AutoMapper;
using Olm.Data.IRepostiries;
using Olm.Service.Interfaces;
using Olm.Service.Exceptions;
using Olm.Service.DTOs.Assigments;
using Olm.Domain.Entities.Assignments;

namespace Olm.Service.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IMapper mapper;
    private readonly IRepository<Assignment> repository;
    public AssignmentService(IRepository<Assignment> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<AssignmentResultDto> AddAsync(AssignmentCreationDto dto)
    {
        var existAssignment = await this.repository.GetAsync(c => c.Title.Equals(dto.Title));
        if (existAssignment is not null)
            throw new AlreadyExistException("This Assignment is already exist");

        var mapped = this.mapper.Map<Assignment>(dto);
        await this.repository.CreateAsync(mapped);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<AssignmentResultDto>(mapped);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var delAssignment = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Assignment is not found with id: {id}");

        this.repository.Delete(delAssignment);
        await repository.SaveAsync();
        return true;
    }

    public async Task<AssignmentResultDto> UpdateAsync(AssignmentUpdateDto dto)
    {
        var Assignment = await this.repository.GetAsync(c => c.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This Assignment is not found with id: {dto.Id}");

        var mappedAssignment = mapper.Map(dto, Assignment);
        this.repository.Update(mappedAssignment);
        await this.repository.SaveAsync();

        var result = mapper.Map<AssignmentResultDto>(mappedAssignment);
        return result;
    }

    public async Task<AssignmentResultDto?> GetByIdAsync(long id)
    {
        var Assignment = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This Assignment is not found with id: {id}");

        var result = mapper.Map<AssignmentResultDto>(Assignment);
        return result;
    }

    public async Task<IEnumerable<AssignmentResultDto>> GetAllAsync()
    {
        var Assignments = this.repository.GetAll();
        var results = new List<AssignmentResultDto>();
        if (Assignments is not null)
            foreach (var Assignment in Assignments)
            {
                var mapped = mapper.Map<AssignmentResultDto>(Assignment);
                results.Add(mapped);
            }
        return results;
    }
}
