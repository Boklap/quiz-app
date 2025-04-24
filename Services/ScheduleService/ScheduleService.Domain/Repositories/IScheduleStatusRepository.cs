using ScheduleService.Domain.Entities;

namespace ScheduleService.Domain.Repositories;

public interface IScheduleStatusRepository
{
    Task<ScheduleStatus?> FindScheduleStatusById(string scheduleStatusId);
}