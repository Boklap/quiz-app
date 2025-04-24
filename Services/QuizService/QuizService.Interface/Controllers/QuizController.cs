using Microsoft.AspNetCore.Mvc;
using QuizService.Application.Dtos;
using QuizService.Application.Ports.Inbound.UseCases;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Interface.Middlewares;

namespace QuizService.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class QuizController : ControllerBase
{
    private readonly ICreateQuizUseCase _createQuizUseCase;
    private readonly IDeleteQuizUseCase _deleteQuizUseCase;
    private readonly IGetPaginatedQuizUseCase _getPaginatedQuizUseCase;
    private readonly IGetPaginatedQuizByCreatorUseCase _getPaginatedQuizByCreatorUseCase;
    private readonly IGetPaginatedQuizByStatusUseCase _getPaginatedQuizByStatusUseCase;
    private readonly IGetPaginatedQuizByTagUseCase _getPaginatedQuizByTagUseCase;
    private readonly ISubmitQuizToBeReviewed _submitQuizToBeReviewed;
    private readonly IRejectQuizUseCase _rejectQuizUseCase;
    private readonly IFinalizeQuizUseCase _finalizeQuizUseCase;
    private readonly IUpdateQuizUseCase _updateQuizUseCase;
    private readonly IGetQuizByIdUseCase _getQuizByIdUseCase;
    private readonly IGetQuizByDateUseCase _getQuizByDateUseCase;
    private readonly IGetQuizByQuizIds _getQuizByQuizIds;

    public QuizController(
        ICreateQuizUseCase createQuizUseCase,
        IDeleteQuizUseCase deleteQuizUseCase,
        IGetPaginatedQuizUseCase getPaginatedQuizUseCase,
        IGetPaginatedQuizByCreatorUseCase getPaginatedQuizByCreatorUseCase,
        IGetPaginatedQuizByStatusUseCase getPaginatedQuizByStatusUseCase,
        IGetPaginatedQuizByTagUseCase getPaginatedQuizByTagUseCase,
        ISubmitQuizToBeReviewed submitQuizToBeReviewed,
        IRejectQuizUseCase reeRejectQuizUseCase,
        IFinalizeQuizUseCase finalizeQuizUseCase,
        IUpdateQuizUseCase updateQuizUseCase,
        IGetQuizByIdUseCase getQuizByIdUseCase,
        IGetQuizByDateUseCase getQuizByDateUseCase, IGetQuizByQuizIds getQuizByQuizIds)
    {
        _createQuizUseCase = createQuizUseCase;
        _deleteQuizUseCase = deleteQuizUseCase;
        _getPaginatedQuizUseCase = getPaginatedQuizUseCase;
        _getPaginatedQuizByCreatorUseCase = getPaginatedQuizByCreatorUseCase;
        _getPaginatedQuizByStatusUseCase = getPaginatedQuizByStatusUseCase;
        _getPaginatedQuizByTagUseCase = getPaginatedQuizByTagUseCase;
        _submitQuizToBeReviewed = submitQuizToBeReviewed;
        _rejectQuizUseCase = reeRejectQuizUseCase;
        _finalizeQuizUseCase = finalizeQuizUseCase;
        _updateQuizUseCase = updateQuizUseCase;
        _getQuizByIdUseCase = getQuizByIdUseCase;
        _getQuizByDateUseCase = getQuizByDateUseCase;
        _getQuizByQuizIds = getQuizByQuizIds;
    }

    [HttpPost("create")]
    [AdminQuizAuthorization]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizDto createQuizDto)
    {
        string quizId = await _createQuizUseCase.Execute(createQuizDto);
        return Ok(quizId);
    }

    [HttpPatch("delete/{quizId}")]
    [AdminQuizAuthorization]
    public async Task<IActionResult> DeleteQuiz(string quizId)
    {
        await _deleteQuizUseCase.Execute(quizId);
        return Ok(new { message = "Quiz deleted" });
    }

    // [HttpGet("get/finalized/{page}/{pageSize}")]
    // public async Task<IActionResult> GetFinalizedQuiz(int page, int pageSize)
    // {
    //     List<QuizDto> quizDtos = await _getPaginatedFinalizedQuiz.Execute(page, pageSize);
    //     return Ok(new { Quizzez = quizDtos });
    // }

    [HttpGet("get/creator/{userId}/{page}/{pageSize}")]
    [AdminQcQuizAuthorization]
    public async Task<IActionResult> GetQuizByCreator(string userId, int page, int pageSize)
    {
        List<QuizDto> quizDtos = await _getPaginatedQuizByCreatorUseCase.Execute(userId, page, pageSize);
        return Ok(new { Quizzez = quizDtos });
    }

    [HttpGet("get/status/{status}/{page}/{pageSize}")]
    [AdminQcQuizAuthorization]
    public async Task<IActionResult> GetQuizByStatus(string status, int page, int pageSize)
    {
        List<QuizDto> quizDtos = await _getPaginatedQuizByStatusUseCase.Execute(status, page, pageSize);
        return Ok(new { Quizzez = quizDtos });
    }

    [HttpGet("get/tag/{tag}/{page}/{pageSize}")]
    [AdminQcQuizAuthorization]
    public async Task<IActionResult> GetQuizByTag(string tag, int page, int pageSize)
    {
        List<QuizDto> quizDtos = await _getPaginatedQuizByTagUseCase.Execute(tag, page, pageSize);
        return Ok(new { Quizzez = quizDtos });
    }

    [HttpGet("get/{page}/{pageSize}")]
    [AdminQcQuizAuthorization]
    public async Task<IActionResult> GetPaginatedQuiz(int page, int pageSize)
    {
        List<QuizDto> quizDtos = await _getPaginatedQuizUseCase.Execute(page, pageSize);
        return Ok(quizDtos);
    }

    [HttpGet("get/{quizId}")]
    public async Task<IActionResult> GetQuizByid(string quizId)
    {
        QuizDto quizDto = await _getQuizByIdUseCase.Execute(quizId);
        return Ok(quizDto);
    }

    [HttpPatch("submit/{quizId}")]
    [AdminQuizAuthorization]
    public async Task<IActionResult> SubmitQuizToBeReviewed(string quizId)
    {
        await _submitQuizToBeReviewed.Execute(quizId);
        return Ok(new { message = "Quiz submitted" });
    }

    [HttpPatch("reject/{quizId}")]
    [AdminQcAuthorization]
    public async Task<IActionResult> RejectQuiz(string quizId)
    {
        await _rejectQuizUseCase.Execute(quizId);
        return Ok(new { message = "Quiz rejected" });
    }

    [HttpPatch("finalize/{quizId}")]
    [AdminQcAuthorization]
    public async Task<IActionResult> FinalizeQuiz(string quizId)
    {
        await _finalizeQuizUseCase.Execute(quizId);
        return Ok(new { message = "Quiz finalize" });
    }

    [HttpPatch("update")]
    [AdminQcQuizAuthorization]
    public async Task<IActionResult> UpdateQuiz([FromBody] UpdateQuizDto quizDto)
    {
        await _updateQuizUseCase.Execute(quizDto);
        return Ok(new { message = "Quiz updated" });
    }

    [HttpGet("get/date")]
    public async Task<IActionResult> GetQuizByDate([FromQuery] DateTime startAt, [FromQuery] DateTime endAt)
    {
        List<QuizDto> quizDtos = await _getQuizByDateUseCase.Execute(startAt, endAt);
        return Ok(quizDtos);
    }

    [HttpPost("get/quizzes")]
    public async Task<IActionResult> GetQuizzes([FromBody] List<string> quizIds)
    {
        Console.WriteLine("dfadhfadfa");
        List<QuizDto> quizDtos = await _getQuizByQuizIds.Execute(quizIds);
        return Ok(quizDtos);
    }
}