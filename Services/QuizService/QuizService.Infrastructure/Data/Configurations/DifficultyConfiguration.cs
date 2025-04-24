using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizService.Domain.Entities;

namespace QuizService.Infrastructure.Data.Configurations;

public class DifficultyConfiguration : IEntityTypeConfiguration<Difficulty>
{
    public void Configure(EntityTypeBuilder<Difficulty> difficulty)
    {
        difficulty.HasKey(d => d.Id);
        difficulty.Property(d => d.Name).IsRequired();
        
        difficulty.HasMany(d => d.Quizzes)
            .WithOne(q => q.Difficulty)
            .HasForeignKey(q => q.DifficultyId)
            .IsRequired();
    }
}