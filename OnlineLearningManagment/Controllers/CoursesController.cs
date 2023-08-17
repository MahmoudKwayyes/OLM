using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Courses;
using Olm.Service.Interfaces;

namespace OnlineLearningManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService courseService;
    public CoursesController(ICourseService courseService)
    {
        this.courseService = courseService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CourseCreationDto course)
    {
        return Ok(await courseService.AddAsync(course));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(CourseUpdateDto course)
    {
        return Ok(await courseService.UpdateAsync(course));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await courseService.RemoveAsync(id));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await courseService.GetByIdAsync(id));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await courseService.GetAllAsync());
    }
}