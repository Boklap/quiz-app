using ScheduleService.Application.Dtos;

namespace ScheduleService.Application.Ports.Inbound;

public interface IGetQuizByScheduleUseCase
{
    Task<List<QuizDto>> Execute(DateTime startDate, DateTime endDate);
}