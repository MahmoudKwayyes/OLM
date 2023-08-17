using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Quizzes;
using Olm.Service.Interfaces;

namespace OnlineLearningManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizsController : ControllerBase
{
    private readonly IQuizService QuizService;
    public QuizsController(IQuizService QuizService)
    {
        this.QuizService = QuizService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(QuizCreationDto Quiz)
    {
        return Ok(await QuizService.AddAsync(Quiz));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(QuizUpdateDto Quiz)
    {
        return Ok(await QuizService.UpdateAsync(Quiz));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await QuizService.RemoveAsync(id));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await QuizService.GetByIdAsync(id));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await QuizService.GetAllAsync());
    }
}
