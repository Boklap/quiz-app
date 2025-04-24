using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizService.Domain.Entities;

namespace QuizService.Infrastructure.Data.Configurations;

public class QuizStatusConfiguration : IEntityTypeConfiguration<QuizStatus>
{
    public void Configure(EntityTypeBuilder<QuizStatus> quizStatus)
    {
        quizStatus.HasKey(qs => qs.Id);
        quizStatus.Property(qs => qs.Name).IsRequired();
        
        quizStatus.HasMany(qs => qs.Quizzes)
            .WithOne(q => q.Status)
            .HasForeignKey(q => q.QuizStatusId)
            .IsRequired();
    }
}