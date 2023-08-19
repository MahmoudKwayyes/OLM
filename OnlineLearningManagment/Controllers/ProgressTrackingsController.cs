using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.ProgressTrackings;
using Olm.Service.Interfaces;
using OnlineLearningManagment.Models;

namespace OnlineLearningManagment.Controllers;

public class ProgressTrackingsController : BaseController
{
    private readonly IProgressTrackingService ProgressTrackingService;
    public ProgressTrackingsController(IProgressTrackingService ProgressTrackingService)
    {
        this.ProgressTrackingService = ProgressTrackingService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(ProgressTrackingCreationDto ProgressTracking)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await ProgressTrackingService.AddAsync(ProgressTracking)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(ProgressTrackingUpdateDto ProgressTracking)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await ProgressTrackingService.UpdateAsync(ProgressTracking)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await ProgressTrackingService.RemoveAsync(id)
        });
    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await ProgressTrackingService.GetByIdAsync(id)
        });
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await ProgressTrackingService.GetAllAsync()
        });
}
