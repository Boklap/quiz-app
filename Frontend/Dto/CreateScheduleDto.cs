namespace Frontend.Dto;

public class CreateScheduleDto
{
    public string QuizId { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int MaxParticipants { get; set; }
}