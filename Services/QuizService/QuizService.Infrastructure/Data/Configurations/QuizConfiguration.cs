using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizService.Domain.Entities;

namespace QuizService.Infrastructure.Data.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> quiz)
    {
        quiz.HasKey(q => q.Id);
        quiz.Property(q => q.CreatedBy).IsRequired();

        quiz.HasOne(q => q.Difficulty)
            .WithMany(d => d.Quizzes)
            .HasForeignKey(q => q.DifficultyId)
            .IsRequired();
        
        quiz.HasOne(q => q.Status)
            .WithMany(d => d.Quizzes)
            .HasForeignKey(q => q.QuizStatusId)
            .IsRequired();
        
        quiz.HasOne(q => q.Tag)
            .WithMany(d => d.Quizzes)
            .HasForeignKey(q => q.TagId)
            .IsRequired();

        quiz.HasMany(q => q.QuizDetails)
            .WithOne(qd => qd.Quiz)
            .HasForeignKey(qd => qd.QuizId)
            .IsRequired();
        
        quiz.OwnsOne(q => q.Name, name =>
        {
            name.Property(n => n.Value)
                .HasMaxLength(255)
                .HasColumnName("Name")
                .IsRequired();
        });
        
        quiz.OwnsOne(q => q.Description, description =>
        {
            description.Property(d => d.Value)
                .HasMaxLength(2000)
                .HasColumnName("Description")
                .IsRequired();
        });
        
        quiz.OwnsOne(q => q.MinimumGrade, minimumGrade =>
        {
            minimumGrade.Property(mg => mg.Value)
                .HasColumnName("MinimumGrade")
                .IsRequired();
        });
        
        quiz.OwnsOne(q => q.TestDuration, testDuration =>
        {
            testDuration.Property(td => td.Value)
                .HasColumnName("TestDuration")
                .IsRequired();
        });
        
        quiz.OwnsOne(q => q.TotalQuestion, totalQuestion =>
        {
            totalQuestion.Property(tq => tq.Value)
                .HasColumnName("TotalQuestion")
                .IsRequired();
        });
        
        quiz.Property(q => q.IsDeleted).IsRequired();
        quiz.Property(q => q.CreatedAt).IsRequired();
        quiz.Property(q => q.UpdatedAt).IsRequired();
        quiz.Property(q => q.DeletedAt).IsRequired(false);
    }
}