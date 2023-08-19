using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.UserEnrollments;
using Olm.Service.Interfaces;
using OnlineLearningManagment.Models;

namespace OnlineLearningManagment.Controllers;

public class UserEnrollmentsController : BaseController
{
    private readonly IUserEnrollmentService UserEnrollmentService;
    public UserEnrollmentsController(IUserEnrollmentService UserEnrollmentService)
    {
        this.UserEnrollmentService = UserEnrollmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(UserEnrollmentCreationDto UserEnrollment)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await UserEnrollmentService.AddAsync(UserEnrollment)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UserEnrollmentUpdateDto UserEnrollment)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await UserEnrollmentService.UpdateAsync(UserEnrollment)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await UserEnrollmentService.RemoveAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await UserEnrollmentService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await UserEnrollmentService.GetAllAsync()
        });
}