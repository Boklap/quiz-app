using Frontend.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace Frontend.Dto;

public class QuestionDto
{
    public string Id { get; set; } = "";
    public string Status { get; set; } = "";
    public string AnswerType { get; set; } = "";
    public double Point { get; set; } = 0;
    public string QuestionText { get; set; } = "";
    public string QuestionImage { get; set; } = "";
    public List<string> Answers { get; set; } = new List<string>();
    public List<string> AnswerImages { get; set; } = new List<string>();
    public List<int> CorrectAnswerIndex { get; set; } = new List<int>();
    public List<Answer> AnswerList = new List<Answer>();
    public IBrowserFile QuestionImageFile { get; set; } = null!;
}