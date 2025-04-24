using Microsoft.AspNetCore.Http;
using QuestionService.Domain.ValueObjects.Question;

namespace QuestionService.Application.Dtos;

public class QuestionDto
{
    public string Id { get; set; }
    public string Status { get; set; }
    public string AnswerType { get; set; }
    public double Point { get; set; }
    public string QuestionText { get; set; }
    public string? QuestionImage { get; set; }
    public List<string>? Answers { get; set; }
    public List<string>? AnswerImages { get; set; }
    public List<int>? CorrectAnswerIndex { get; set; }
}