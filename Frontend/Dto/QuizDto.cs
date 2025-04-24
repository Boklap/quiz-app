namespace Frontend.Dto;

public class QuizDto
{
    public string Id { get; set; }
    public string DifficultyId { get; set; }
    public string StatusId { get; set; }
    public string TagId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MinimumGrade { get; set; }
    public int TestDuration { get; set; }
    public int TotalQuestion { get; set; }
}