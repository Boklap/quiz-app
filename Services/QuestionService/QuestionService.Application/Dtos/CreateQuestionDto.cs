using Microsoft.AspNetCore.Http;

namespace QuestionService.Application.Dtos;

public class CreateQuestionDto
{
    public string AnswerType { get; set; }
    public string QuestionText { get; set; }
    public IFormFile? QuestionImage { get; set; }
    public List<string> Answers { get; set; }
    public List<string> ImageNames { get; set; }
    public List<IFormFile>? AnswerImages { get; set; }
    public List<int>? CorrectAnswerIndex { get; set; }
    public double Point { get; set; }
}