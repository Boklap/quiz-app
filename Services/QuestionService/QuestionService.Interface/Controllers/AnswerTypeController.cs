using Microsoft.AspNetCore.Mvc;
using QuestionService.Application.Ports.Inbound.UseCases;

namespace QuestionService.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class AnswerTypeController : ControllerBase
{
    private readonly IGetAnswerTypesUseCase _getAnswerTypesUseCase;

    public AnswerTypeController(IGetAnswerTypesUseCase getAnswerTypesUseCase)
    {
        _getAnswerTypesUseCase = getAnswerTypesUseCase;
    }

    [HttpGet("get")]
    public async Task<ActionResult> GetAnswerTypes()
    {
        List<string> answerTypeList = await _getAnswerTypesUseCase.Execute();
        return Ok(answerTypeList);
    }
}