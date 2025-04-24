using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Infrastructure.Data.Configurations;

public class ScheduleDetailConfiguration : IEntityTypeConfiguration<ScheduleDetail>
{
    public void Configure(EntityTypeBuilder<ScheduleDetail> scheduleDetail)
    {
        scheduleDetail.HasKey(sd => new { sd.ScheduleId, sd.ParticipantId });

        scheduleDetail.HasOne(sd => sd.Schedule)
            .WithMany(s => s.ScheduleDetails)
            .HasForeignKey(sd => sd.ScheduleId)
            .IsRequired();
        
        scheduleDetail.Property(sd => sd.IsDeleted).IsRequired();
        scheduleDetail.Property(sd => sd.CreatedAt).IsRequired();
        scheduleDetail.Property(sd => sd.UpdatedAt).IsRequired();
        scheduleDetail.Property(sd => sd.DeletedAt).IsRequired(false);
    }
}