using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Quizzes;
using Olm.Service.Interfaces;

namespace OnlineLearningManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService QuestionService;
    public QuestionsController(IQuestionService QuestionService)
    {
        this.QuestionService = QuestionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(QuestionCreationDto Question)
    {
        return Ok(await QuestionService.AddAsync(Question));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(QuestionUpdateDto Question)
    {
        return Ok(await QuestionService.UpdateAsync(Question));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await QuestionService.RemoveAsync(id));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await QuestionService.GetByIdAsync(id));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await QuestionService.GetAllAsync());
    }
}
