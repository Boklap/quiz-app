namespace QuizService.Domain.Entities;

public class QuizStatus
{
    public string Id { get; set; }
    public  string Name { get; set; }
    public ICollection<Quiz> Quizzes { get; set; } = null!;

    public QuizStatus()
    {
    }

    public QuizStatus(string id, string name)
    {
        Id = id;
        Name = name;
    }
}