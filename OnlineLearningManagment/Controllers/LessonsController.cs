using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Lessons;
using Olm.Service.Interfaces;
using OnlineLearningManagment.Models;

namespace OnlineLearningManagment.Controllers;

public class LessonsController : BaseController
{
    private readonly ILessonService LessonService;
    public LessonsController(ILessonService LessonService)
    {
        this.LessonService = LessonService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(LessonCreationDto Lesson)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await LessonService.AddAsync(Lesson)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(LessonUpdateDto Lesson)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await LessonService.UpdateAsync(Lesson)
        });
    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await LessonService.RemoveAsync(id)
        });
    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await LessonService.GetByIdAsync(id)
        });
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await LessonService.GetAllAsync()
        });
}
