using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ScheduleService.Shared.Utilities;

namespace ScheduleService.Infrastructure.Data;

public class ScheduleServiceDbContextFactory : IDesignTimeDbContextFactory<ScheduleServiceDbContext>    
{
    public ScheduleServiceDbContext CreateDbContext(string[] args)
    {
        EnvLoader.Load();
        
        var optionsBuilder = new DbContextOptionsBuilder<ScheduleServiceDbContext>();
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        
        optionsBuilder.UseNpgsql(connectionString);
        return new ScheduleServiceDbContext(optionsBuilder.Options);
    }
}