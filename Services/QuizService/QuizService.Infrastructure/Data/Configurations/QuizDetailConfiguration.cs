using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizService.Domain.Entities;

namespace QuizService.Infrastructure.Data.Configurations;

public class QuizDetailConfiguration : IEntityTypeConfiguration<QuizDetail>
{
    public void Configure(EntityTypeBuilder<QuizDetail> quizDetail)
    {
        quizDetail.HasKey(qd => new { qd.QuizId, qd.QuestionId });

        quizDetail.HasOne(qd => qd.Quiz)
            .WithMany(q => q.QuizDetails)
            .HasForeignKey(q => q.QuizId)
            .IsRequired();

        quizDetail.Property(qd => qd.IsDeleted).IsRequired();
        quizDetail.Property(qd => qd.CreatedAt).IsRequired();
        quizDetail.Property(qd => qd.UpdatedAt).IsRequired();
        quizDetail.Property(qd => qd.DeletedAt).IsRequired(false);
    }
}