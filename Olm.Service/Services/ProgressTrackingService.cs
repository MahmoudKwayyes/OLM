using AutoMapper;
using Olm.Data.IRepostiries;
using Olm.Service.Interfaces;
using Olm.Service.Exceptions;
using Olm.Service.DTOs.ProgressTrackings;
using Olm.Domain.Entities.ProgressTrackings;

namespace Olm.Service.Services;

public class ProgressTrackingService : IProgressTrackingService
{
    private readonly IMapper mapper;
    private readonly IRepository<ProgressTracking> repository;
    public ProgressTrackingService(IRepository<ProgressTracking> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<ProgressTrackingResultDto> AddAsync(ProgressTrackingCreationDto dto)
    {
        var mapped = this.mapper.Map<ProgressTracking>(dto);
        await this.repository.CreateAsync(mapped);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<ProgressTrackingResultDto>(mapped);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var delProgressTracking = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This ProgressTracking is not found with id: {id}");

        this.repository.Delete(delProgressTracking);
        await repository.SaveAsync();
        return true;
    }

    public async Task<ProgressTrackingResultDto> UpdateAsync(ProgressTrackingUpdateDto dto)
    {
        var ProgressTracking = await this.repository.GetAsync(c => c.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This ProgressTracking is not found with id: {dto.Id}");

        var mappedProgressTracking = mapper.Map(dto, ProgressTracking);
        this.repository.Update(mappedProgressTracking);
        await this.repository.SaveAsync();

        var result = mapper.Map<ProgressTrackingResultDto>(mappedProgressTracking);
        return result;
    }

    public async Task<ProgressTrackingResultDto?> GetByIdAsync(long id)
    {
        var ProgressTracking = await this.repository.GetAsync(c => c.Id.Equals(id))
          ?? throw new NotFoundException($"This ProgressTracking is not found with id: {id}");

        var result = mapper.Map<ProgressTrackingResultDto>(ProgressTracking);
        return result;
    }

    public async Task<IEnumerable<ProgressTrackingResultDto>> GetAllAsync()
    {
        var ProgressTrackings = this.repository.GetAll();
        var results = new List<ProgressTrackingResultDto>();
        if (ProgressTrackings is not null)
            foreach (var ProgressTracking in ProgressTrackings)
            {
                var mapped = mapper.Map<ProgressTrackingResultDto>(ProgressTracking);
                results.Add(mapped);
            }
        return results;
    }
}
