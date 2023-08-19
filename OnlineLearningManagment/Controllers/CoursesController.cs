using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Courses;
using Olm.Service.Interfaces;
using OnlineLearningManagment.Models;

namespace OnlineLearningManagment.Controllers;

public class CoursesController : BaseController
{
    private readonly ICourseService courseService;
    public CoursesController(ICourseService courseService)
    {
        this.courseService = courseService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CourseCreationDto course)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.AddAsync(course)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(CourseUpdateDto course)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.UpdateAsync(course)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.RemoveAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.GetAllAsync()
        });
}