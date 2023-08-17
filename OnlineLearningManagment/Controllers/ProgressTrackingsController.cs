using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.ProgressTrackings;
using Olm.Service.Interfaces;

namespace OnlineLearningManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgressTrackingsController : ControllerBase
{
    private readonly IProgressTrackingService ProgressTrackingService;
    public ProgressTrackingsController(IProgressTrackingService ProgressTrackingService)
    {
        this.ProgressTrackingService = ProgressTrackingService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(ProgressTrackingCreationDto ProgressTracking)
    {
        return Ok(await ProgressTrackingService.AddAsync(ProgressTracking));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(ProgressTrackingUpdateDto ProgressTracking)
    {
        return Ok(await ProgressTrackingService.UpdateAsync(ProgressTracking));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await ProgressTrackingService.RemoveAsync(id));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await ProgressTrackingService.GetByIdAsync(id));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await ProgressTrackingService.GetAllAsync());
    }
}
