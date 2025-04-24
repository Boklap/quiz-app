using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Infrastructure.Data.Configurations;

public class ScheduleStatusConfiguration : IEntityTypeConfiguration<ScheduleStatus>
{
    public void Configure(EntityTypeBuilder<ScheduleStatus> scheduleStatus)
    {
        scheduleStatus.HasKey(ss => ss.Id);
        scheduleStatus.Property(ss => ss.Name)
            .IsRequired();

        scheduleStatus.HasMany(ss => ss.Schedule)
            .WithOne(s => s.Status)
            .HasForeignKey(s => s.StatusId)
            .IsRequired();
    }
}