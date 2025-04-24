namespace ScheduleService.Domain.Entities;

public class ScheduleStatus
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<Schedule> Schedule { get; set; }

    public ScheduleStatus()
    {
    }

    public ScheduleStatus(string id, string name)
    {
        Id = id;
        Name = name;
    }
}