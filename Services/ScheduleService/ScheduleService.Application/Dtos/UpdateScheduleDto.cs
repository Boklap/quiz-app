namespace ScheduleService.Application.Dtos;

public class UpdateScheduleDto
{
    public string Id { get; set; }
    public string QuizId { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int MaxParticipants { get; set; }
}