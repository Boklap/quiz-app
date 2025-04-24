using QuizResultService.Application.Dtos;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Application.Ports.Inbound.Admin;

public interface IGetPaginatedQuizResultByScheduleUseCase
{
    Task<List<QuizResultDto>> Execute(string scheduleId, int page, int pageSize);
    Task<List<QuizResult>?> GetQuizResultBySchedule(string scheduleId, int page, int pageSize);
}