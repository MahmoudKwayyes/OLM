using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Assigments;
using Olm.Service.Interfaces;
using OnlineLearningManagment.Models;

namespace OnlineLearningManagment.Controllers;

public class AssignmentsController : BaseController
{
    private readonly IAssignmentService AssignmentService;
    public AssignmentsController(IAssignmentService AssignmentService)
    {
        this.AssignmentService = AssignmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(AssignmentCreationDto Assignment)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AssignmentService.AddAsync(Assignment)
        });
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(AssignmentUpdateDto Assignment)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AssignmentService.UpdateAsync(Assignment)
        });
    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AssignmentService.RemoveAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AssignmentService.GetByIdAsync(id)
        });
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AssignmentService.GetAllAsync()
        });
}
