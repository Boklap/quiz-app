using MongoDB.Bson;

namespace QuizResultService.Domain.Entities;

public class QuizResultStatus
{
    public ObjectId Id { get; set; }
    public required string Name { get; set; }

    public QuizResultStatus() {}

    public QuizResultStatus(ObjectId id, string name)
    {
        Id = id;
        Name = name;
    }
}