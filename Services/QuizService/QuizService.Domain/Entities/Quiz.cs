using QuizService.Domain.ValueObjects.Quiz;

namespace QuizService.Domain.Entities;

public class Quiz
{
    public string Id { get; set; }
    public string CreatedBy { get; set; }
    public string DifficultyId { get; set; }
    public string TagId { get; set; }
    public string QuizStatusId { get; set; }
    public Difficulty Difficulty { get; set; }
    public QuizStatus Status { get; set; }
    public Tag Tag { get; set; }
    public ICollection<QuizDetail> QuizDetails { get; set; }
    public Name Name { get; set; }
    public Description Description { get; set; }
    public MinimumGrade MinimumGrade { get; set; }
    public TestDuration TestDuration { get; set; }
    public TotalQuestion TotalQuestion { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public Quiz()
    {
    }
    
    public Quiz(
        string id,
        string createdBy,
        string difficultyId,
        string tagId,
        Name name,
        Description description,
        MinimumGrade minimumGrade,
        TestDuration testDuration,
        TotalQuestion totalQuestion,
        bool isDeleted = false,
        DateTime? createdAt = null,
        DateTime? updatedAt = null,
        DateTime? deletedAt = null)
    {
        Id = id;
        CreatedBy = createdBy;
        DifficultyId = difficultyId;
        TagId = tagId;
        QuizStatusId = "1";
        Name = name;
        Description = description;
        MinimumGrade = minimumGrade;
        TestDuration = testDuration;
        TotalQuestion = totalQuestion;
        IsDeleted = isDeleted;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = updatedAt ?? DateTime.UtcNow;
        DeletedAt = deletedAt;
    }

    public void UpdateQuiz(
        string difficultyId,
        string tagId,
        string name,
        string description,
        int minimumGrade,
        int testDuration,
        int totalQuestion)
    {
        DifficultyId = difficultyId;
        TagId = tagId;
        Name = new Name(name);
        Description = new Description(description);
        MinimumGrade = new MinimumGrade(minimumGrade);
        TestDuration = new TestDuration(testDuration);
        TotalQuestion = new TotalQuestion(totalQuestion);
    }
}