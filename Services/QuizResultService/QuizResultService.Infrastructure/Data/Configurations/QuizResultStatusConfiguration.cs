using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Infrastructure.Data.Configurations;

public class QuizResultStatusConfiguration : IEntityTypeConfiguration<QuizResultStatus>
{
    public void Configure(EntityTypeBuilder<QuizResultStatus> quizResultStatus)
    {
        quizResultStatus.ToCollection("QuizResultStatuses");
    }
}