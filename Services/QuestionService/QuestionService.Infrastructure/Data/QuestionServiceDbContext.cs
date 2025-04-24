using Microsoft.EntityFrameworkCore;
using QuestionService.Domain.Entities;
// using QuestionService.Domain.ValueObjects.Question;

namespace QuestionService.Infrastructure.Data;

public class QuestionServiceDbContext : DbContext
{
    public QuestionServiceDbContext(DbContextOptions<QuestionServiceDbContext> options) : base(options)
    {
    }
    
    public DbSet<Question> Questions { get; init; }
    public DbSet<AnswerType> AnswerType { get; init; }
    public DbSet<QuestionStatus> QuestionStatuses { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionServiceDbContext).Assembly);
    }
}