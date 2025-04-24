using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;
using ScheduleService.Infrastructure.Data;

namespace ScheduleService.Infrastructure.Repositories;

public class ScheduleRepositoryImpl : IScheduleRepository
{
    private ScheduleServiceDbContext _context;

    public ScheduleRepositoryImpl(ScheduleServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task InsertSchedule(Schedule schedule)
    {
        await _context.Schedules.AddAsync(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task<Schedule?> FindScheduleById(string scheduleId)
    {
        return await _context.Schedules
            .Where(s => !s.IsDeleted)
            .FirstOrDefaultAsync(s => s.Id == scheduleId);
    }

    public async Task<List<Schedule>> GetPaginatedSchedule(int page, int pageSize)
    {
        return await _context.Schedules
            .Where(s => !s.IsDeleted) 
            .Skip((page - 1) * pageSize)  
            .Take(pageSize) 
            .ToListAsync();
    }

    public async Task<List<Schedule>> GetPaginatedScheduleByDate(DateTime startDate, DateTime endDate, int page, int pageSize)
    {
        return await _context.Schedules
            .Where(s => !s.IsDeleted && s.StartAt >= startDate && s.EndAt <= endDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Schedule>> GetPaginatedScheduleByStatus(string statusId, int page, int pageSize)
    {
        return await _context.Schedules
            .Where(s => !s.IsDeleted && s.StatusId == statusId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<string>?> GetQuizIdBySchedule(DateTime startAt, DateTime endAt)
    {
        return await _context.Schedules
            .Where(s => s.StartAt >= startAt && s.StartAt <= endAt)
            .Select(s => s.QuizId)
            .ToListAsync();
    }

    public async Task UpdateSchedule(Schedule schedule)
    {
        _context.Schedules.Update(schedule);
        await _context.SaveChangesAsync();
    }
}