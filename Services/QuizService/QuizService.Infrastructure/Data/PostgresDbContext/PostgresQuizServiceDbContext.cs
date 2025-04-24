using Microsoft.EntityFrameworkCore;
using QuizService.Domain.Entities;
using QuizService.Domain.ValueObjects.Quiz;

namespace QuizService.Infrastructure.Data.PostgresDbContext;

public class PostgresQuizServiceDbContext : DbContext
{
    public PostgresQuizServiceDbContext(DbContextOptions<PostgresQuizServiceDbContext> options) : base(options)
    {
    }
    
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<QuizDetail> QuizDetails { get; set; }
    public DbSet<QuizStatus> QuizStatuses { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresQuizServiceDbContext).Assembly);
    }
}