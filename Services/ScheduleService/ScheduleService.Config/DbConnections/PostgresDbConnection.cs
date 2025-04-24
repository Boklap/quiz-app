using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Infrastructure.Data;

namespace ScheduleService.Config.DbConnections;

public static class PostgresDbConnection
{
    public static IServiceCollection AddPostgresDbConnection(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        services.AddDbContext<ScheduleServiceDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        return services;
    }
}