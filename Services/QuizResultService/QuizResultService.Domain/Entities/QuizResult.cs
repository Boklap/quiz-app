using MongoDB.Bson;
using QuizResultService.Domain.ValueObjects.QuizResult;

namespace QuizResultService.Domain.Entities;

public class QuizResult
{
    public ObjectId Id { get; set; }
    public string ParticipantId { get; set; }
    public string GradedBy { get; set; }
    public Schedule Schedule { get; set; }
    public Quiz Quiz { get; set; }
    public string Status { get; set; }
    public Score Score { get; set; }
    public string Reason { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public QuizResult()
    {
    }

    public QuizResult(
        string participantId,
        Schedule schedule,
        Quiz quiz,
        Score score,
        bool isDeleted = false,
        DateTime? createdAt = null,
        DateTime? updatedAt = null,
        DateTime? deletedAt = null)
    {
        Id = ObjectId.GenerateNewId();
        ParticipantId = participantId;
        GradedBy = "";
        Schedule = schedule;
        Quiz = quiz;
        Status = "";
        Score = score;
        Reason = "";
        IsDeleted = isDeleted;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = updatedAt ?? DateTime.UtcNow;
        DeletedAt = deletedAt;
    }

    public void Update(
        double score,
        string reason)
    {
        Score = new Score(score);
        Reason = reason;
    }
    
}