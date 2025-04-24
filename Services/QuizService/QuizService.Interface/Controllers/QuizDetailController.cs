using Microsoft.AspNetCore.Mvc;
using QuizService.Application.Dtos;
using QuizService.Application.Ports.Inbound.UseCases.QuizDetailUseCases;
using QuizService.Application.UseCases.QuizDetailUseCaseImpl;
using QuizService.Domain.ValueObjects.FinalizedQuizDetail;

namespace QuizService.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class QuizDetailController : ControllerBase
{
    private readonly IGetQuestionsByQuizIdUseCase _getQuestionsByQuizIdUseCase;
    private readonly IAddQuestionToQuizDetailUseCase _addQuestionToQuizDetailUseCase;

    public QuizDetailController(IGetQuestionsByQuizIdUseCase getQuestionsByQuizIdUseCase, IAddQuestionToQuizDetailUseCase addQuestionToQuizDetailUseCase)
    {
        _getQuestionsByQuizIdUseCase = getQuestionsByQuizIdUseCase;
        _addQuestionToQuizDetailUseCase = addQuestionToQuizDetailUseCase;
    }

    [HttpGet("get/questions/{quizId}")]
    public async Task<IActionResult> GetQuizQuestions(string quizId)
    {
        List<QuestionDto> questionsList = await _getQuestionsByQuizIdUseCase.Execute(quizId);
        return Ok(questionsList);
    }

    [HttpPost("add/questions")]
    public async Task<IActionResult> InsertQuestionToQuiz(AddQuestionToQuizDto addQuestionToQuizDto)
    {
        await _addQuestionToQuizDetailUseCase.Execute(addQuestionToQuizDto);
        return Ok("Question added to quiz");
    }
    
}