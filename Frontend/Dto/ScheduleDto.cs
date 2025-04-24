namespace Frontend.Dto;

public class ScheduleDto
{
    public string StatusId { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int MaxParticipants { get; set; }
}