using QuizResultService.Domain.ValueObjects.QuizResult;

namespace QuizResultService.Application.Dtos;

public class CreateQuizResultDto
{
    public required string ParticipantId { get; set; }
    public Schedule Schedule { get; set; }
    public Quiz Quiz { get; set; }
    public Score Score { get; set; }
}