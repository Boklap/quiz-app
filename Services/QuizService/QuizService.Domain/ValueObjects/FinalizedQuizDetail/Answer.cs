using QuizService.Domain.ValueObjects.Shared;

namespace QuizService.Domain.ValueObjects.FinalizedQuizDetail;

public class Answer
{
    public required List<string> AnswerList { get; set; }
    public required List<string> ImagePath { get; set; }
}