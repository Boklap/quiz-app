using Microsoft.AspNetCore.Mvc;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;

namespace QuestionService.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionStatusController : ControllerBase
{
    private readonly IGetQuestionStatusUseCase _getQuestionStatusUseCase;

    public QuestionStatusController(IGetQuestionStatusUseCase getQuestionStatusUseCase)
    {
        _getQuestionStatusUseCase = getQuestionStatusUseCase;
    }

    [HttpGet("get")]
    public async Task<ActionResult> FetchQuestionStatus()
    {
        List<string>? questionStatuses = await _getQuestionStatusUseCase.Execute();
        return Ok(questionStatuses);
    }
}