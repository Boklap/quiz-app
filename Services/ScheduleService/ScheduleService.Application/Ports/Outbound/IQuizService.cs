using ScheduleService.Application.Dtos;

namespace ScheduleService.Application.Ports.Outbound;

public interface IQuizService
{
    Task<List<QuizDto>> GetQuizBySchedule(DateTime startAt, DateTime endAt);
    Task<List<QuizDto>> GetQuizByIds(List<string> quizIds);
}