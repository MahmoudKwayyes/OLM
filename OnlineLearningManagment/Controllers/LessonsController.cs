using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Lessons;
using Olm.Service.Interfaces;

namespace OnlineLearningManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly ILessonService LessonService;
    public LessonsController(ILessonService LessonService)
    {
        this.LessonService = LessonService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(LessonCreationDto Lesson)
    {
        return Ok(await LessonService.AddAsync(Lesson));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(LessonUpdateDto Lesson)
    {
        return Ok(await LessonService.UpdateAsync(Lesson));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await LessonService.RemoveAsync(id));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await LessonService.GetByIdAsync(id));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await LessonService.GetAllAsync());
    }
}
