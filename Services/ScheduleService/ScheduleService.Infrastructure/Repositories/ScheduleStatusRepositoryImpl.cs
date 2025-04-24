using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;
using ScheduleService.Infrastructure.Data;

namespace ScheduleService.Infrastructure.Repositories;

public class ScheduleStatusRepositoryImpl : IScheduleStatusRepository
{
    private readonly ScheduleServiceDbContext _context;

    public ScheduleStatusRepositoryImpl(ScheduleServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task<ScheduleStatus?> FindScheduleStatusById(string scheduleStatusId)
    {
        return await _context.ScheduleStatuses.FirstOrDefaultAsync(s => s.Id == scheduleStatusId);
    }
}