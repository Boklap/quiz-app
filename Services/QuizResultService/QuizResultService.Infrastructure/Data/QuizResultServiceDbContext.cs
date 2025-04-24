using Microsoft.EntityFrameworkCore;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Infrastructure.Data;

public class QuizResultServiceDbContext : DbContext
{
    public QuizResultServiceDbContext(DbContextOptions<QuizResultServiceDbContext> options) : base(options)
    {
    }
    
    public DbSet<QuizResult> QuizResults { get; set; }
    public DbSet<QuizResultAnswer> QuizResultAnswers { get; set; }
    public DbSet<QuizResultQuestion> QuizResultQuestions { get; set; }
    public DbSet<QuizResultStatus> QuizResultStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuizResultServiceDbContext).Assembly);
    }
}