namespace QuizResultService.Application.Dtos;

public class UpdateQuizResultDto
{
    public string QuizResultId { get; set; }
    public double Score { get; set; }
    public string Reason { get; set; }
}