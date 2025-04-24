using QuizService.Config.DbConnections;
using QuizService.Config.Wirings;
using QuizService.Shared.Utilities;

namespace QuizService.Interface.Extensions;

public static class ServiceExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        EnvLoader.Load();
        
        services.AddOpenApi();
        services.AddHttpContextAccessor();
        services.AddHttpClient();
        services.AddMongoDbConnection();
        services.AddRedisConnection();
        services.AddPostgresDbConnection();
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        services.AddQuizServiceWiring();
        services.AddQuizDetailServiceWiring();
        services.AddTagServiceWiring();
        services.AddDifficultyServiceWiring();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins(Environment.GetEnvironmentVariable("FRONT_END_URL"));
            });
        });
        services.AddCors(options =>
        {
            options.AddPolicy("AllowScheduleBackend", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins(Environment.GetEnvironmentVariable("SCHEDULE_BACKEND_URL"));
            });
        });
    }
}