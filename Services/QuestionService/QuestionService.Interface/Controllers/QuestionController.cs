using Microsoft.AspNetCore.Mvc;
using QuestionService.Application.Dtos;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Interface.Middlewares;

namespace QuestionService.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionController : ControllerBase
{
    private readonly ICreateQuestionUseCase _createQuestionUseCase;
    private readonly IDeleteQuestionUseCase _deleteQuestionUseCase;
    private readonly IGetPaginatedQuestionUseCase _getPaginatedQuestionUseCase;
    private readonly IGetQuestionByAdminUseCase _getQuestionByAdminUseCase;
    private readonly IGetQuestionByStatusUseCase _getQuestionByStatusUseCase;
    private readonly ISubmitQuestionToBeReviewed _submitQuestionToBeReviewed;
    private readonly IRejectQuestionUseCase _rejectQuestionUseCase;
    private readonly IFinalizeQuestionUseCase _finalizeQuestionUseCase;
    private readonly IUpdateQuestionUseCase _updateQuestionUseCase;
    private readonly IGetQuestionsbyQuestionIds _getQuestionsbyQuestionIds;
    private readonly IGetQuestionById _getQuestionById;
    
    public QuestionController(
        ICreateQuestionUseCase createQuestionUseCase,
        IDeleteQuestionUseCase deleteQuestionUseCase,
        IGetPaginatedQuestionUseCase getPaginatedQuestionUseCase,
        IGetQuestionByAdminUseCase getQuestionByAdminUseCase,
        IGetQuestionByStatusUseCase getQuestionByStatusUseCase,
        ISubmitQuestionToBeReviewed submitQuestionToBeReviewed,
        IRejectQuestionUseCase rejectQuestionUseCase,
        IFinalizeQuestionUseCase finalizeQuestionUseCase,
        IUpdateQuestionUseCase updateQuestionUseCase,
        IGetQuestionsbyQuestionIds getQuestionsbyQuestionIds,
        IGetQuestionById getQuestionById)
    {
        _createQuestionUseCase = createQuestionUseCase;
        _deleteQuestionUseCase = deleteQuestionUseCase;
        _getPaginatedQuestionUseCase = getPaginatedQuestionUseCase;
        _getQuestionByAdminUseCase = getQuestionByAdminUseCase;
        _getQuestionByStatusUseCase = getQuestionByStatusUseCase;
        _submitQuestionToBeReviewed = submitQuestionToBeReviewed;
        _rejectQuestionUseCase = rejectQuestionUseCase;
        _finalizeQuestionUseCase = finalizeQuestionUseCase;
        _updateQuestionUseCase = updateQuestionUseCase;
        _getQuestionsbyQuestionIds = getQuestionsbyQuestionIds;
        _getQuestionById = getQuestionById;
    }

    [HttpPost("create")]
    [Consumes("multipart/form-data")]
    [AdminQuizAuthorization]
    public async Task<ActionResult> CreateQuestion([FromForm] CreateQuestionDto createQuestionDto)
    {
        var userId = HttpContext.Items["UserId"]?.ToString();

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("User not authorized");
        }

        await _createQuestionUseCase.Execute(createQuestionDto);
        return Ok(new { message = "Question Created" });
    }

    [HttpPatch("delete/{questionId}")]
    [AdminQuizAuthorization]
    public async Task<ActionResult> DeleteQuestion(string questionId)
    {
        await _deleteQuestionUseCase.Execute(questionId);
        return Ok(new { message = "Question Deleted" });
    }

    [HttpGet("get/{page}/{pageSize}")]
    [AdminQcQuizAuthorization]
    public async Task<ActionResult> GetPaginatedQuestions(int page, int pageSize)
    {
        List<QuestionDto> questionList = await _getPaginatedQuestionUseCase.Execute(page, pageSize);
        return Ok(questionList);
    }

    [HttpGet("get/creator/{userId}/{page}/{pageSize}")]
    [AdminQcQuizAuthorization]
    public async Task<ActionResult> GetQuestionByCreator(string userId, int page, int pageSize)
    {
        List<QuestionDto> questionList = await _getQuestionByAdminUseCase.Execute(userId, page, pageSize);
        return Ok(new { questions = questionList });
    }

    [HttpGet("get/status/{status}/{page}/{pageSize}")]
    [AdminQcQuizAuthorization]
    public async Task<ActionResult> GetQuestionByStatus(string status, int page, int pageSize)
    {
        List<QuestionDto> questionList = await _getQuestionByStatusUseCase.Execute(status, page, pageSize);
        foreach (var q in questionList)
        {
            Console.WriteLine($"{q.Id} - {q.Status}");
        }
        return Ok(new { questions = questionList });
    }

    [HttpPatch("update")]
    [AdminQuizAuthorization]
    public async Task<ActionResult> UpdateQuestion([FromForm] UpdateQuestionDto questionDto)
    {
        await _updateQuestionUseCase.Execute(questionDto);
        return Ok(new { message = "Question Updated" });
    }

    [HttpPatch("submit/{questionId}")]
    [AdminQuizAuthorization]
    public async Task<ActionResult> SubmitQuestion(string questionId)
    {
        await _submitQuestionToBeReviewed.Execute(questionId);
        return Ok(new { message = "Question Submitted" });
    }
    
    [HttpPatch("reject/{questionId}")]
    [AdminQcAuthorization]
    public async Task<ActionResult> RejectQuestion(string questionId)
    {
        await _rejectQuestionUseCase.Execute(questionId);
        return Ok(new { message = "Question Rejected" });
    }
    
    [HttpPatch("finalize/{questionId}")]
    [AdminQcAuthorization]
    public async Task<ActionResult> FinalizeQuestion(string questionId)
    {
        await _finalizeQuestionUseCase.Execute(questionId);
        return Ok(new { message = "Question Finalized" });
    }

    [HttpPost("get/questions")]
    public async Task<ActionResult> GetQuestionsByQuestoinIds([FromBody] List<string> questionIds)
    {
        List<QuestionRequestDto> questionList = await _getQuestionsbyQuestionIds.GetQuestionsByIds(questionIds);
        return Ok(questionList);
    }

    [HttpGet("get/{questionId}")]
    public async Task<ActionResult> GetQuestionById(string questionId)
    {
        QuestionDto? question = await _getQuestionById.Execute(questionId);
        if (question is null) return Ok();
        
        return Ok(question);
    }
}