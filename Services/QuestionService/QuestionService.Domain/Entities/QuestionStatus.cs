using MongoDB.Bson;

namespace QuestionService.Domain.Entities;

public class QuestionStatus
{
    public required ObjectId Id { get; set; }
    public required string Name { get; set; }
}