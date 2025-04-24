using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Infrastructure.Data.Configurations;

public class QuizResultAnswers : IEntityTypeConfiguration<QuizResultAnswer>
{
    public void Configure(EntityTypeBuilder<QuizResultAnswer> quizResultDetail)
    {
        quizResultDetail.ToCollection("QuizResultAnswers");
    }
}