using MongoDB.Bson;

namespace QuizResultService.Domain.ValueObjects.QuizResultAnswer;

public class Question
{
    public ObjectId Id { get; set; }
    public string QuestionText { get; set; }
    public List<string> QuestionImages { get; set; }
    public Answer Answer { get; set; }
    public double point { get; set; }

    public Question()
    {
    }

    public Question(
        ObjectId id,
        string questionText,
        List<string> questionImages,
        Answer answer,
        double point)
    {
        Id = id;
        QuestionText = questionText;
        QuestionImages = questionImages;
        Answer = answer;
        this.point = point;
    }
}