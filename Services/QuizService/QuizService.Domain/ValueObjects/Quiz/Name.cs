using QuizService.Shared;
using QuizService.Shared.Exceptions;

namespace QuizService.Domain.ValueObjects.Quiz;

public class Name
{
    public string Value { get; }

    public Name(string value)
    {
        ValidationResult validationResult = IsValid(value);
        if (!validationResult.IsValid)
        {
            throw new InvalidAttributeException(validationResult.Message);
        }
        
        Value = value;
    }
    
    private ValidationResult IsValid(string value)
    {
        if (IsEmpty(value))
        {
            return ValidationResult.Failure("Username cannot be empty.");
        }

        if (IsExceedLength(value))
        {
            return ValidationResult.Failure("Username must be between 1 and 255 Characters");
        }
        
        return ValidationResult.Success();
    }

    private bool IsEmpty(string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    private bool IsExceedLength(string value)
    {
        return value.Length > 255;
    }

    public override string ToString() => Value;
    
    public override bool Equals(object? obj)
    {
        if (obj is Name other)
            return Value.Equals(other.Value, StringComparison.Ordinal);
    
        return false;
    }
    
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);
}