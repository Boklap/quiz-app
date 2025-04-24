using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace Frontend.Models;

public class CreateQuestionModel
{
    [Required(ErrorMessage = "AnswerType harus diisi.")]
    public string AnswerType { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "AnswerType harus diisi.")]
    public string QuestionText { get; set; } = string.Empty;
    public IBrowserFile QuestionImage { get; set; }
    public List<Answer> Answers { get; set; } = new List<Answer>();
    public List<int>? CorrectAnswerIndex { get; set; } = new List<int>();

    [Required(ErrorMessage = "Point harus diisi.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Point harus lebih dari 0.")]
    public double Point { get; set; }
}