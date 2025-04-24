namespace ScheduleService.Application.Dtos;

public class ScheduleDto
{
    public string StatudId { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int MaxParticipants { get; set; }
}