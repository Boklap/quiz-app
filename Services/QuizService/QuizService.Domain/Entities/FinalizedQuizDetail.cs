using MongoDB.Bson;
using QuizService.Domain.ValueObjects.FinalizedQuizDetail;
using QuizService.Domain.ValueObjects.Quiz;

namespace QuizService.Domain.Entities;

public class FinalizedQuizDetail
{
    public ObjectId Id { get; set; }
    public Name Name { get; set; }
    public Description Description { get; set; }
    public MinimumGrade MinimumGrade { get; set; }
    public TestDuration TestDuration { get; set; }
    public TotalQuestion TotalQuestion { get; set; }
    public List<Question> Questions { get; set; }
    public DateTime CreatedAt { get; set; }

    public FinalizedQuizDetail()
    {
    }
}