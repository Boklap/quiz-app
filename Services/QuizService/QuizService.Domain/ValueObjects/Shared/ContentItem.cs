namespace QuizService.Domain.ValueObjects.Shared;

public class ContentItem
{
    public string Type { get; set; } // "text" | "image"
    public string Value { get; set; }

    public ContentItem(string type, string value)
    {
        Type = type;
        Value = value;
    }
}