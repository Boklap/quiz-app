namespace QuizResultService.Domain.ValueObjects.QuizResultAnswer;

public class Answer
{
    public required List<string> AnswerList { get; set; }
    public required List<string> ImagePath { get; set; }
}