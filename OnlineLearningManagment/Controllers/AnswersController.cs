using Microsoft.AspNetCore.Mvc;
using Olm.Service.DTOs.Quizzes;
using Olm.Service.Interfaces;
using OnlineLearningManagment.Models;

namespace OnlineLearningManagment.Controllers;

public class AnswersController : BaseController
{
    private readonly IAnswerService AnswerService;
    public AnswersController(IAnswerService AnswerService)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = this.AnswerService = AnswerService
        });
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(AnswerCreationDto Answer)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AnswerService.AddAsync(Answer)
        });
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(AnswerUpdateDto Answer)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AnswerService.UpdateAsync(Answer)
        });
    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AnswerService.RemoveAsync(id)
        });
    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AnswerService.GetByIdAsync(id)
        });
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await AnswerService.GetAllAsync()
        });
}