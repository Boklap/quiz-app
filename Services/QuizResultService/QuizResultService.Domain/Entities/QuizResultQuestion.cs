using QuizResultService.Domain.ValueObjects.QuizResult;
using QuizResultService.Domain.ValueObjects.QuizResultAnswer;

namespace QuizResultService.Domain.Entities;

public class QuizResultQuestion
{
    public string ParticipantId { get; set; }
    public string ScheduleId { get; set; }
    public string QuizId { get; set; }
    public List<Question> Questions { get; set; }

    public QuizResultQuestion(
        string participantId,
        string scheduleId,
        string quizId,
        List<Question> questions)
    {
        ParticipantId = participantId;
        ScheduleId = scheduleId;
        QuizId = quizId;
        Questions = questions;
    }
}