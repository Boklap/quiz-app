using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizService.Domain.Entities;

namespace QuizService.Infrastructure.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> tag)
    {
        tag.HasKey(t => t.Id);
        tag.Property(t => t.Name).IsRequired();

        tag.HasMany(t => t.Quizzes)
            .WithOne(q => q.Tag)
            .HasForeignKey(q => q.TagId)
            .IsRequired();
    }
}