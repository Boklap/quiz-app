using QuizService.Shared;
using QuizService.Shared.Exceptions;

namespace QuizService.Domain.ValueObjects.Quiz;

public class MinimumGrade
{
    public int Value { get; }

    public MinimumGrade(int value)
    {
        ValidationResult validationResult = IsValid(value);
        if (!validationResult.IsValid)
        {
            throw new InvalidAttributeException(validationResult.Message);
        }
        
        Value = value;
    }

    private ValidationResult IsValid(int value)
    {
        if (!IsMoreThanZero(value))
        {
            return ValidationResult.Failure("Minimum grade must be greater than zero");
        }
        
        return ValidationResult.Success();
    }

    private bool IsMoreThanZero(int value)
    {
        return value > 0;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is MinimumGrade other)
            return Value == other.Value;
    
        return false;
    }
    
    public override int GetHashCode() => Value.GetHashCode();
}