using MongoDB.Bson;

namespace QuestionService.Domain.Entities;

public class AnswerType
{
    public required ObjectId Id { get; set; }
    public required string Name { get; set; }

    public AnswerType()
    {
    }
}