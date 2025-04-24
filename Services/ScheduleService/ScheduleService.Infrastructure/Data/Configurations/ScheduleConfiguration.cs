using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Infrastructure.Data.Configurations;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> schedule)
    {
        schedule.HasKey(s => s.Id);
        schedule.Property(s => s.QuizId).IsRequired();
        schedule.Property(s => s.StatusId).IsRequired();
        schedule.Property(s => s.CreatedBy).IsRequired();
        schedule.Property(s => s.StartAt).IsRequired();
        schedule.Property(s => s.EndAt).IsRequired();

        schedule.HasOne(s => s.Status)
            .WithMany(ss => ss.Schedule)
            .HasForeignKey(s => s.StatusId)
            .IsRequired();
        
        schedule.HasMany(s => s.ScheduleDetails)
            .WithOne(sd => sd.Schedule)
            .HasForeignKey(sd => sd.ScheduleId)
            .IsRequired();
        
        schedule.OwnsOne(s => s.MaxParticipant, maxParticipant =>
        {
            maxParticipant.Property(mp => mp.Value)
                .HasColumnName("MaxParticipant")
                .IsRequired();
        });
        
        schedule.Property(s => s.IsDeleted).IsRequired();
        schedule.Property(s => s.CreatedAt).IsRequired();
        schedule.Property(s => s.UpdatedAt).IsRequired();
        schedule.Property(s => s.DeletedAt).IsRequired(false);
    }
}