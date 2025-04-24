using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using QuestionService.Domain.Entities;

namespace QuestionService.Infrastructure.Data.Configruations;

public class AnswerTypeConfiguration : IEntityTypeConfiguration<AnswerType>
{
    public void Configure(EntityTypeBuilder<AnswerType> answerType)
    {
        answerType.ToCollection("AnswerType");
    }
}