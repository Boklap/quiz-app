namespace QuizService.Domain.Entities;

public class QuizDetail
{
    public string QuizId { get; set; }
    public string QuestionId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Quiz Quiz { get; set; }
    
    public QuizDetail()
    {
    }

    public QuizDetail(string quizId, string questionId)
    {
        QuizId = quizId;
        QuestionId = questionId;
        IsDeleted = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        DeletedAt = null;
    }

    public void Update()
    {
        
    }
}