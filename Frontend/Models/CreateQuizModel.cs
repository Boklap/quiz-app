using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;

public class CreateQuizModel
{
    [Required]
    public string Tag { get; set; }

    [Required]
    public string Difficulty { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Range(0, 100)]
    public int MinimumGrade { get; set; }

    [Range(1, 300)]
    public int TestDuration { get; set; }
}