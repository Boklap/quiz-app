using QuizService.Shared;
using QuizService.Shared.Exceptions;

namespace QuizService.Domain.ValueObjects.Quiz;

public class Description
{
    public string Value { get; }

    public Description(string value)
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
            return ValidationResult.Failure("Description cannot be empty.");
        }
        
        if (IsExceedLength(value))
        {
            return ValidationResult.Failure("Description cannot be more than 2000 characters");
        }
        
        return ValidationResult.Success();
    }

    private bool IsEmpty(string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
    
    private bool IsExceedLength(string value)
    {
        return value.Length > 2000;
    }

    public override string ToString() => Value;
    
    public override bool Equals(object? obj)
    {
        if (obj is Description other)
            return Value.Equals(other.Value, StringComparison.Ordinal);
    
        return false;
    }
    
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);
}