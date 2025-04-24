using System.ComponentModel.DataAnnotations;

namespace QuizService.Application.Dtos;

public class CreateQuizDto
{
    public string DifficultyId { get; set; }
    public string TagId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public int MinimumGrade { get; set; }
    [Required]
    public int TestDuration { get; set; }
    [Required]
    public int TotalQuestion { get; set; }
}