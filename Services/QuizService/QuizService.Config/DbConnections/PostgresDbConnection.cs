using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizService.Infrastructure.Data.PostgresDbContext;

namespace QuizService.Config.DbConnections;

public static class PostgresDbConnection
{
    public static IServiceCollection AddPostgresDbConnection(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

        services.AddDbContext<PostgresQuizServiceDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        return services;
    }
}