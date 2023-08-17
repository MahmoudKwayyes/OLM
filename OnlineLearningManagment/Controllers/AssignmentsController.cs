using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Assigments;
using Olm.Service.Interfaces;

namespace OnlineLearningManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentsController : ControllerBase
{
    private readonly IAssignmentService AssignmentService;
    public AssignmentsController(IAssignmentService AssignmentService)
    {
        this.AssignmentService = AssignmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(AssignmentCreationDto Assignment)
    {
        return Ok(await AssignmentService.AddAsync(Assignment));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(AssignmentUpdateDto Assignment)
    {
        return Ok(await AssignmentService.UpdateAsync(Assignment));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await AssignmentService.RemoveAsync(id));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await AssignmentService.GetByIdAsync(id));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await AssignmentService.GetAllAsync());
    }
}