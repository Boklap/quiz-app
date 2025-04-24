namespace QuizService.Domain.Entities;

public class Tag
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<Quiz> Quizzes { get; set; } = null!;

    public Tag()
    {
    }

    public Tag(string id, string name)
    {
        Id = id;
        Name = name;
    }
}