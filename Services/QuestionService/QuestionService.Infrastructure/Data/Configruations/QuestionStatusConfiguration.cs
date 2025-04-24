using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using QuestionService.Domain.Entities;

namespace QuestionService.Infrastructure.Data.Configruations;

public class QuestionStatusConfiguration : IEntityTypeConfiguration<QuestionStatus>
{
    public void Configure(EntityTypeBuilder<QuestionStatus> questionStatus)
    {
        questionStatus.ToCollection("QuestionStatus");
    }
}