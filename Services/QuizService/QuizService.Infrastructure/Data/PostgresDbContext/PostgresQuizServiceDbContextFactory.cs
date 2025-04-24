using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QuizService.Shared.Utilities;

namespace QuizService.Infrastructure.Data.PostgresDbContext;

public class PostgresQuizServiceDbContextFactory : IDesignTimeDbContextFactory<PostgresQuizServiceDbContext>    
{
    public PostgresQuizServiceDbContext CreateDbContext(string[] args)
    {
        EnvLoader.Load();
        
        var optionsBuilder = new DbContextOptionsBuilder<PostgresQuizServiceDbContext>();
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");
        
        optionsBuilder.UseNpgsql(connectionString);
        return new PostgresQuizServiceDbContext(optionsBuilder.Options);
    }
}