using MongoDB.Bson;
using QuestionService.Domain.ValueObjects.Question;

namespace QuestionService.Domain.Entities;

    
public class Question
{
    public ObjectId Id { get; set; }
    public string CreatedBy { get; set; }
    public string Status { get; set; }
    public string AnswerType { get; set; }
    public string QuestionText { get; set; }
    public string QuestionImage { get; set; }
    public Point Point { get; set; }
    public Answer Answer { get; set; }
    public List<int>? CorrectAnswerIndex { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public Question(){}
    
    public Question(
        string createdBy,
        string answerType,
        double point,
        Answer answer,
        List<int>? correctAnswerIndex,
        string questionImages,
        bool isDeleted = false,
        string questionText = "",
        DateTime? createdAt = null,
        DateTime? updatedAt = null,
        DateTime? deletedAt = null)
    {
        Id = ObjectId.GenerateNewId();
        CreatedBy = createdBy;
        Status = "Draft";
        AnswerType = answerType;
        Point = new Point(point);
        QuestionText = questionText;
        QuestionImage = questionImages;
        Answer = answer;
        CorrectAnswerIndex = correctAnswerIndex;
        IsDeleted = isDeleted;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = updatedAt ?? DateTime.UtcNow;
        DeletedAt = deletedAt;
    }
    
    public void UpdateQuestion(
        string questionText,
        string answerType,
        string questionStatus,
        double point,
        Answer answer,
        List<int>? correctAnswerIndex,
        string questionImages)
    {
        QuestionText = questionText;
        AnswerType = answerType;
        Status = questionStatus;
        Point = new Point(point);
        Answer = answer;
        CorrectAnswerIndex = correctAnswerIndex;
        QuestionImage = questionImages;
    }
}