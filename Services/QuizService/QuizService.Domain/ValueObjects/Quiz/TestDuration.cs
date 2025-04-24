using QuizService.Shared;
using QuizService.Shared.Exceptions;

namespace QuizService.Domain.ValueObjects.Quiz;

public class TestDuration
{
    public int Value { get; }

    public TestDuration(int value)
    {
        ValidationResult result = IsValid(value);
        if (!result.IsValid)
        {
            throw new InvalidAttributeException(result.Message);
        }
        
        Value = value;
    }
    
    private ValidationResult IsValid(int value)
    {
        if (!IsMoreThanZero(value))
        {
            return ValidationResult.Failure("Minimum test duration must be greater than zero");
        }
        
        return ValidationResult.Success();
    }

    private bool IsMoreThanZero(int value)
    {
        return value > 0;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is TestDuration other)
            return Value == other.Value;
    
        return false;
    }
    
    public override int GetHashCode() => Value.GetHashCode();
}