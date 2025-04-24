using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Dtos;
using ScheduleService.Application.Ports.Inbound;
using ScheduleService.Interface.Middlewares;

namespace ScheduleService.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly ICreateScheduleUseCase _createScheduleUseCase;
    private readonly IDeleteScheduleUseCase _deleteScheduleUseCase;
    private readonly IGetPaginatedScheduleByDateUseCase _getPaginatedScheduleByDateUseCase;
    private readonly IGetPaginatedScheduleByStatusUseCase _getPaginatedScheduleByStatusUseCase;
    private readonly IGetPaginatedScheduleUseCase _getPaginatedScheduleUseCase;
    private readonly IUpdateScheduleUseCase _updateScheduleUseCase;
    private readonly IGetQuizByScheduleUseCase _getQuizByScheduleUseCase;

    public ScheduleController(
        ICreateScheduleUseCase createScheduleUseCase,
        IDeleteScheduleUseCase deleteScheduleUseCase,
        IGetPaginatedScheduleByDateUseCase getPaginatedScheduleByDateUseCase,
        IGetPaginatedScheduleByStatusUseCase getPaginatedScheduleByStatusUseCase,
        IGetPaginatedScheduleUseCase getPaginatedScheduleUseCase,
        IUpdateScheduleUseCase updateScheduleUseCase,
        IGetQuizByScheduleUseCase getQuizByScheduleUseCase)
    {
        _createScheduleUseCase = createScheduleUseCase;
        _deleteScheduleUseCase = deleteScheduleUseCase;
        _getPaginatedScheduleByDateUseCase = getPaginatedScheduleByDateUseCase;
        _getPaginatedScheduleByStatusUseCase = getPaginatedScheduleByStatusUseCase;
        _getPaginatedScheduleUseCase = getPaginatedScheduleUseCase;
        _updateScheduleUseCase = updateScheduleUseCase;
        _getQuizByScheduleUseCase = getQuizByScheduleUseCase;
    }

    [HttpPost("create")]
    [AdminSchedulerAuthorization]
    public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleDto createScheduleDto)
    {
        await _createScheduleUseCase.Execute(createScheduleDto);
        return Ok(new { message = "Schedule created successfully" });
    }

    [HttpPatch("delete")]
    [AdminSchedulerAuthorization]
    public async Task<IActionResult> DeleteSchedule(string quizId)
    {
        await _deleteScheduleUseCase.Execute(quizId);
        return Ok(new { message = "Schedule deleted successfully" });
    }

    [HttpGet("get/date")]
    [AdminSchedulerQuizManagerAuthorization]
    public async Task<IActionResult> GetPaginatedScheduleByDate(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate,
        [FromQuery] int page,
        [FromQuery] int pageSize)
    {
        List<ScheduleDto> scheduleDto = await _getPaginatedScheduleByDateUseCase.Execute(startDate, endDate, page, pageSize);
        return Ok(new { scheduleDto });
    }

    [HttpGet("get/status/{statusId}/{page}/{pageSize}")]
    [AdminSchedulerQuizManagerAuthorization]
    public async Task<IActionResult> GetPaginatedScheduleByStatus(string statusId, int page, int pageSize)
    {
        List<ScheduleDto> schedule = await _getPaginatedScheduleByStatusUseCase.Execute(statusId, page, pageSize);
        return Ok(new { schedule });
    }

    [HttpGet("get/{page}/{pageSize}")]
    [AdminSchedulerQuizManagerAuthorization]
    public async Task<IActionResult> GetPaginatedSchedule(int page, int pageSize)
    {
        List<ScheduleDto> schedule = await _getPaginatedScheduleUseCase.Execute(page, pageSize);
        return Ok(new { schedule });
    }

    [AdminSchedulerAuthorization]
    [HttpPatch("update")]
    public async Task<IActionResult> UpdateSchedule([FromBody] UpdateScheduleDto updateScheduleDto)
    {
        await _updateScheduleUseCase.Execute(updateScheduleDto);
        return Ok(new { message = "Schedule updated successfully" });
    }
    
    [HttpGet("get/quiz")]
    public async Task<IActionResult> GetQuizScheduleByDate([FromQuery] DateTime startAt, [FromQuery] DateTime endAt)
    {
        List<QuizDto> quizzes = await _getQuizByScheduleUseCase.Execute(startAt, endAt);
        return Ok(quizzes);
    }
}