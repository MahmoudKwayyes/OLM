using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Quizzes;
using Olm.Service.Interfaces;
using OnlineLearningManagment.Models;

namespace OnlineLearningManagment.Controllers;

public class QuizsController : BaseController
{
    private readonly IQuizService QuizService;
    public QuizsController(IQuizService QuizService)
    {
        this.QuizService = QuizService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(QuizCreationDto Quiz)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuizService.AddAsync(Quiz)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(QuizUpdateDto Quiz)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuizService.UpdateAsync(Quiz)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuizService.RemoveAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuizService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await QuizService.GetAllAsync()
        });
}
