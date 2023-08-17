using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Quizzes;
using Olm.Service.Interfaces;

namespace OnlineLearningManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswersController : ControllerBase
{
    private readonly IAnswerService AnswerService;
    public AnswersController(IAnswerService AnswerService)
    {
        this.AnswerService = AnswerService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(AnswerCreationDto Answer)
    {
        return Ok(await AnswerService.AddAsync(Answer));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(AnswerUpdateDto Answer)
    {
        return Ok(await AnswerService.UpdateAsync(Answer));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await AnswerService.RemoveAsync(id));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await AnswerService.GetByIdAsync(id));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await AnswerService.GetAllAsync());
    }
}