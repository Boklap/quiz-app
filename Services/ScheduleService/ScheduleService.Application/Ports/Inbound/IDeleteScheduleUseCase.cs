using ScheduleService.Domain.Entities;

namespace ScheduleService.Application.Ports.Inbound;

public interface IDeleteScheduleUseCase
{
    public Task Execute(string scheduleId);
    public Task<Schedule?> IsScheduleExist(string scheduleId);
    public Task DeleteSchedule(Schedule schedule);
}