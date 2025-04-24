using QuizService.Domain.ValueObjects.Shared;

namespace QuizService.Domain.ValueObjects.FinalizedQuizDetail;

public class Question
{
    public string Id { get; set; }
    public string AnswerType { get; set; }
    public double Point { get; set; }
    public string QuestionText { get; set; }
    public string QuestionImages { get; set; }
    public Answer Answer { get; set; }
    public List<int> CorrectAnswerIdx { get; set; }
}