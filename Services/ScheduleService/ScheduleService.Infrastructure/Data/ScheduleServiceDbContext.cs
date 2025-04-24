using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Infrastructure.Data;

public class ScheduleServiceDbContext : DbContext
{
    public ScheduleServiceDbContext(DbContextOptions<ScheduleServiceDbContext> options) : base(options)
    {
    }
    
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<ScheduleDetail> ScheduleDetails { get; set; }
    public DbSet<ScheduleStatus> ScheduleStatuses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduleServiceDbContext).Assembly);
    }
}