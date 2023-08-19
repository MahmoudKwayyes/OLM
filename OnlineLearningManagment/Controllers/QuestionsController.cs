using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Quizzes;
using Olm.Service.Interfaces;
using OnlineLearningManagment.Models;

namespace OnlineLearningManagment.Controllers;

public class QuestionsController : BaseController
{
    private readonly IQuestionService QuestionService;
    public QuestionsController(IQuestionService QuestionService)
    {
        this.QuestionService = QuestionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(QuestionCreationDto Question)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuestionService.AddAsync(Question)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(QuestionUpdateDto Question)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuestionService.UpdateAsync(Question)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuestionService.RemoveAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuestionService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuestionService.GetAllAsync()
        });
}
