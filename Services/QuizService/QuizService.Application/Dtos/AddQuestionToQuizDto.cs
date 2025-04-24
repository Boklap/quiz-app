namespace QuizService.Application.Dtos;

public class AddQuestionToQuizDto
{
    public string QuizId { get; set; }
    public List<string> Questions { get; set; }
}