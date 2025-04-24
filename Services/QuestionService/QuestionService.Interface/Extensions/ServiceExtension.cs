using QuestionService.Config.DbConnections;
using QuestionService.Config.MessageBrokerConnection;
using QuestionService.Config.Wirings;
// using QuestionService.Config.Wirings;
using QuestionService.Shared.Utilities;

namespace QuestionService.Interface.Extensions;

public static class ServiceExtension
{
    public static async Task RegisterServices(this IServiceCollection services)
    {
        EnvLoader.Load();
        
        services.AddOpenApi();
        services.AddHttpContextAccessor();
        services.AddMongoDbConnection();
        await services.AddRabbitMqConnection();
        
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
            options.AddPolicy("AllowQuizBackend", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins(Environment.GetEnvironmentVariable("QUIZ_BACKEND_URL"));
            });
        });
        
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        
        services.AddCreateQuestionWiring();
    }
}