using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace QuizService.Config.DbConnections;

public static class RedisConnection
{
    public static IServiceCollection AddRedisConnection(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING");
        var password = Environment.GetEnvironmentVariable("REDIS_PASSWORD");

        ConfigurationOptions conf = new ConfigurationOptions
        {
            EndPoints = { connectionString },
            Password = password
        };
        
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(conf);
        
        services.AddSingleton<IConnectionMultiplexer>(redis);

        return services;
    }
}