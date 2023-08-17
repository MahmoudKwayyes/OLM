using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.UserEnrollments;
using Olm.Service.Interfaces;

namespace OnlineLearningManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserEnrollmentsController : ControllerBase
{
    private readonly IUserEnrollmentService UserEnrollmentService;
    public UserEnrollmentsController(IUserEnrollmentService UserEnrollmentService)
    {
        this.UserEnrollmentService = UserEnrollmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(UserEnrollmentCreationDto UserEnrollment)
    {
        return Ok(await UserEnrollmentService.AddAsync(UserEnrollment));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UserEnrollmentUpdateDto UserEnrollment)
    {
        return Ok(await UserEnrollmentService.UpdateAsync(UserEnrollment));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await UserEnrollmentService.RemoveAsync(id));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await UserEnrollmentService.GetByIdAsync(id));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await UserEnrollmentService.GetAllAsync());
    }
}