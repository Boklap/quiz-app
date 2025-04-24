using QuizResultService.Config.DbConnections;
using QuizResultService.Config.Wirings;
using QuizResultService.Shared.Utilities;

namespace QuizResultService.Interface.Extensions;

public static class ServiceExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        EnvLoader.Load();
        
        services.AddOpenApi();
        services.AddHttpContextAccessor();
        services.AddMongoDbConnection();
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        services.AddQuizResultServiceWiring();
    }
}