using QuestionService.Domain.ValueObjects.Question;

namespace QuestionService.Application.Dtos;

public class QuestionRequestDto
{
    public string Id { get; set; }
    public string AnswerType { get; set; }
    public double Point { get; set; }
    public string QuestionText { get; set; }
    public string QuestionImage { get; set; }
    public Answer Answer { get; set; }
    public List<int>? CorrectAnswerIdx { get; set; }
}