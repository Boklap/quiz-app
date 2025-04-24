using Microsoft.AspNetCore.Mvc;
using QuizResultService.Application.Dtos;
using QuizResultService.Application.Ports.Inbound.Admin;
using QuizResultService.Application.Ports.Inbound.Participant;
using QuizResultService.Domain.ValueObjects.QuizResultAnswer;
using QuizResultService.Interface.Middlewares;

namespace QuizResultService.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class QuizResultController : ControllerBase
{
    private readonly ICreateQuizResultUseCase _createQuizResultUseCase;
    private readonly IGetPaginatedQuizResultByQuizUseCase _getPaginatedQuizResultByQuizUseCase;
    private readonly IGetPaginatedQuizResultByScheduleUseCase _getPaginatedQuizResultByScheduleUseCase;
    private readonly IGetPaginatedQuizResultByStatusUseCase _getPaginatedQuizResultByStatusUseCase;
    private readonly IGradeQuizResultUseCase _gradeQuizResultUseCase;
    private readonly IGetPaginatedQuizResultByParticipantUseCase _getPaginatedQuizResultByParticipantUseCase;
    private readonly IGetPaginatedQuestionByQuizUseCase _getPaginatedQuestionByQuizUseCase;
    
    public QuizResultController(
        ICreateQuizResultUseCase createQuizResultUseCase, 
        IGetPaginatedQuizResultByQuizUseCase getPaginatedQuizResultByQuizUseCase, 
        IGetPaginatedQuizResultByScheduleUseCase getPaginatedQuizResultByScheduleUseCase, 
        IGetPaginatedQuizResultByStatusUseCase getPaginatedQuizResultByStatusUseCase, 
        IGradeQuizResultUseCase gradeQuizResultUseCase, 
        IGetPaginatedQuizResultByParticipantUseCase getPaginatedQuizResultByParticipantUseCase,
        IGetPaginatedQuestionByQuizUseCase getPaginatedQuestionByQuizUseCase)
    {
        _createQuizResultUseCase = createQuizResultUseCase;
        _getPaginatedQuizResultByQuizUseCase = getPaginatedQuizResultByQuizUseCase;
        _getPaginatedQuizResultByScheduleUseCase = getPaginatedQuizResultByScheduleUseCase;
        _getPaginatedQuizResultByStatusUseCase = getPaginatedQuizResultByStatusUseCase;
        _gradeQuizResultUseCase = gradeQuizResultUseCase;
        _getPaginatedQuizResultByParticipantUseCase = getPaginatedQuizResultByParticipantUseCase;
        _getPaginatedQuestionByQuizUseCase = getPaginatedQuestionByQuizUseCase;
    }

    [HttpPost("participant/create")]
    [UserAuthorization]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizResultDto createQuizResultDto)
    {
        await _createQuizResultUseCase.Execute(createQuizResultDto);
        return Ok(new { message = "Answer submitted successfully" });
    }

    [HttpGet("admin/get/quiz/{quizId}/{page}/{pageSize}")]
    [AdminQuizManagerGradingAuthorization]
    public async Task<IActionResult> GetQuizResultByQuizId(string quizId, int page, int pageSize)
    {
        List<QuizResultDto> quizResultDtos = await _getPaginatedQuizResultByQuizUseCase.Execute(quizId, page, pageSize);
        return Ok(new { quizResults = quizResultDtos });
    }
    
    [HttpGet("admin/get/schedule/{scheduleId}/{page}/{pageSize}")]
    [AdminQuizManagerGradingAuthorization]
    public async Task<IActionResult> GetQuizResultBySchedule(string scheduleId, int page, int pageSize)
    {
        List<QuizResultDto> quizResultDtos = await _getPaginatedQuizResultByScheduleUseCase.Execute(scheduleId, page, pageSize);
        return Ok(new { quizResults = quizResultDtos });
    }
    
    [HttpGet("admin/get/status/{statusId}/{page}/{pageSize}")]
    [AdminQuizManagerGradingAuthorization]
    public async Task<IActionResult> GetQuizResultByStatus(string statusId, int page, int pageSize)
    {
        List<QuizResultDto> quizResultDtos = await _getPaginatedQuizResultByStatusUseCase.Execute(statusId, page, pageSize);
        return Ok(new { quizResults = quizResultDtos });
    }

    [HttpPatch("grade")]
    [AdminQuizGradingAuthorization]
    public async Task<IActionResult> GradeQuizResult([FromBody] UpdateQuizResultDto updateQuizResultDto)
    {
        await _gradeQuizResultUseCase.Execute(updateQuizResultDto);
        return Ok(new { message = "Quiz Graded" });
    }

    [HttpGet("participant/get/participant/{page}/{pageSize}")]
    [UserAuthorization]
    public async Task<IActionResult> GetQuizResultByParticipant(int page, int pageSize)
    {
        List<QuizResultDto> quizResultDtos = await _getPaginatedQuizResultByParticipantUseCase.Execute(page, pageSize);
        return Ok(new { quizResults = quizResultDtos });
    }

    [HttpGet("participant/get/question/{quizId}/{page}/{pageSize}")]
    public async Task<IActionResult> GetQuestionByQuiz(string quizId, int page, int pageSize)
    {
        List<Question> questionList = await _getPaginatedQuestionByQuizUseCase.Execute(quizId, page, pageSize);
        return Ok(new { questions = questionList });
    }
}