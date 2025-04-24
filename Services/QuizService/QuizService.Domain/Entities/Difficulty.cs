namespace QuizService.Domain.Entities;

public class Difficulty
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<Quiz> Quizzes { get; set; } = null!;

    public Difficulty()
    {
    }
    
    public Difficulty(string id, string name)
    {
        Id = id;
        Name = name;
    }
}