using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using QuestionService.Infrastructure.Data;

namespace QuestionService.Config.DbConnections;

public static class MongoDbConnection
{
    public static IServiceCollection AddMongoDbConnection(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("MONGO_DB_CONNECTION_STRING");
        var dbName = Environment.GetEnvironmentVariable("MONGO_DB_NAME");
        
        var client = new MongoClient(connectionString);
        IMongoDatabase database = client.GetDatabase(dbName);

        services.AddDbContext<QuestionServiceDbContext>(options =>
        {
            options.UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName);
        });

        return services;
    }
}