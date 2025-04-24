using ScheduleService.Domain.ValueObjects.Schedule;

namespace ScheduleService.Domain.Entities;

public class Schedule
{
    public string Id { get; set; }
    public string QuizId { get; set; }
    public string StatusId { get; set; }
    public string CreatedBy { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public MaxParticipant MaxParticipant { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public ScheduleStatus Status { get; set; }
    public ICollection<ScheduleDetail> ScheduleDetails { get; set; }

    public Schedule()
    {
    }
    
    public Schedule(
        string id,
        string quizId,
        string createdBy,
        DateTime startAt,
        DateTime endAt,
        int maxParticipant,
        bool isDeleted = false,
        DateTime? createdAt = null,
        DateTime? updatedAt = null,
        DateTime? deletedAt = null)
    {
        Id = id;
        QuizId = quizId;
        StatusId = "1";
        CreatedBy = createdBy;
        StartAt = startAt;
        EndAt = endAt;
        MaxParticipant = new MaxParticipant(maxParticipant);
        IsDeleted = isDeleted;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = updatedAt ?? DateTime.UtcNow;
        DeletedAt = deletedAt;
    }

    public void UpdateSchedule(
        string quizId,
        DateTime startAt,
        DateTime endAt,
        int maxParticipant
        )
    {
        QuizId = quizId;
        StartAt = startAt;
        EndAt = endAt;
        MaxParticipant = new MaxParticipant(maxParticipant);
    }
}