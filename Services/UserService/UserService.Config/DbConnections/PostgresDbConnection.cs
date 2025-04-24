using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Data;

namespace UserService.Config.DbConnections;

public static class PostgresDbConnection
{
    public static IServiceCollection AddPostgresDbConnection(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        services.AddDbContext<UserServiceDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        return services;
    }
}