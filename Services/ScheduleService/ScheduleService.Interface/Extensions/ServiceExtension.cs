using ScheduleService.Config.DbConnections;
using ScheduleService.Config.Wirings;
using ScheduleService.Shared.Utilities;

namespace ScheduleService.Interface.Extensions;

public static class ServiceExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        EnvLoader.Load();

        services.AddOpenApi();
        services.AddHttpContextAccessor();
        services.AddHttpClient();
        services.AddPostgresDbConnection();
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
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        services.AddScheduleWiring();
    }
}