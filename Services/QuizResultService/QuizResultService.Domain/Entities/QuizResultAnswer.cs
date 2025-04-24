using MongoDB.Bson;
using QuizResultService.Domain.ValueObjects.QuizResultAnswer;

namespace QuizResultService.Domain.Entities;

public class QuizResultAnswer
{
    public ObjectId Id { get; set; }
    public string ParticipantId { get; set; }
    public string ScheduleId { get; set; }
    public string QuizId { get; set; }
    public string QuestionId { get; set; }
    public Answer Answer { get; set; }
    public bool IsCorrect { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public QuizResultAnswer()
    {
    }

    public QuizResultAnswer(
        string participantId,
        string scheduleId,
        string quizId,
        string questionId,
        Answer answer,
        bool isCorrect,
        bool isDeleted = false,
        DateTime? createdAt = null,
        DateTime? deletedAt = null)
    {
        Id = ObjectId.GenerateNewId();
        ParticipantId = participantId;
        ScheduleId = scheduleId;
        QuizId = quizId;
        QuestionId = questionId;
        Answer = answer;
        IsCorrect = isCorrect;
        IsDeleted = isDeleted;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        DeletedAt = deletedAt;
    }
}