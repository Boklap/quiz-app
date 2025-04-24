using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using QuestionService.Domain.Entities;

namespace QuestionService.Infrastructure.Data.Configruations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> question)
    {
        question.ToCollection("Question");
    }
}