using ScheduleService.Domain.Entities;

namespace ScheduleService.Domain.Repositories;

public interface IScheduleRepository
{
    Task InsertSchedule(Schedule schedule);
    Task<Schedule?> FindScheduleById(string scheduleId);
    Task<List<Schedule>> GetPaginatedSchedule(int page, int pageSize);
    Task<List<Schedule>> GetPaginatedScheduleByDate(DateTime startDate, DateTime endDate, int page, int pageSize);
    Task<List<Schedule>> GetPaginatedScheduleByStatus(string statusId, int page, int pageSize);
    Task<List<string>?> GetQuizIdBySchedule(DateTime startAt, DateTime endAt);
    Task UpdateSchedule(Schedule schedule);
}