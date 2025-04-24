namespace QuizResultService.Domain.ValueObjects.QuizResult;

public class Schedule
{
    public string Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string Status { get; set; }

    public Schedule()
    {
    }

    public Schedule(string id, DateTime startAt, DateTime endAt, string status)
    {
        Id = id;
        StartAt = startAt;
        EndAt = endAt;
        Status = status;
    }
}