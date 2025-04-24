using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Infrastructure.Data.Configurations;

public class QuizResultQuestionsConfiguration : IEntityTypeConfiguration<QuizResultQuestion>
{
    public void Configure(EntityTypeBuilder<QuizResultQuestion> quizResultQuestion)
    {
        quizResultQuestion.ToCollection("QuizResultQuestions");
    }
}