using Microsoft.EntityFrameworkCore;
using QuizService.Domain.Entities;

namespace QuizService.Infrastructure.Data.MongoDbContext;

public class MongoQuizServiceDbContext : DbContext
{
    public MongoQuizServiceDbContext(DbContextOptions<MongoQuizServiceDbContext> options) : base(options)
    {
    }
    
    public DbSet<FinalizedQuizDetail> FinalizedQuizDetails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MongoQuizServiceDbContext).Assembly);
    }
}