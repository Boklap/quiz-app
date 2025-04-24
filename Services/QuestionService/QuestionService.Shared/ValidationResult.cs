namespace QuestionService.Shared;

public class ValidationResult
{
    private ValidationResult(bool isValid, string message)
    {
        IsValid = isValid;
        Message = message;
    }
    
    public bool IsValid { get; }
    public string Message { get; }

    public static ValidationResult Success() => new(true, string.Empty);
    public static ValidationResult Failure(string message) => new(false, message); 
}