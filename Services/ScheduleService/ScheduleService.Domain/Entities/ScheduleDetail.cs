namespace ScheduleService.Domain.Entities;

public class ScheduleDetail
{
    public string ScheduleId { get; set; }
    public string ParticipantId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Schedule Schedule { get; set; }

    public ScheduleDetail()
    {
    }

    public ScheduleDetail(
        string scheduleId, 
        string participantId, 
        bool isDeleted = false,
        DateTime? createdAt = null,
        DateTime? updatedAt = null,
        DateTime? deletedAt = null)
    {
        ScheduleId = scheduleId;
        ParticipantId = participantId;
        IsDeleted = isDeleted;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = updatedAt ?? DateTime.UtcNow;
        DeletedAt = deletedAt;
    }
}