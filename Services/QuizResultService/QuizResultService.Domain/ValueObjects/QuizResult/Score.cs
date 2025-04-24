using QuizResultService.Shared;
using QuizResultService.Shared.Exceptions;

namespace QuizResultService.Domain.ValueObjects.QuizResult;

public class Score
{
    public double Value { get; }

    public Score()
    {
    }

    public Score(double value)
    {
        ValidationResult validationResult = IsValid(value);
        if (!validationResult.IsValid)
        {
            throw new InvalidAttributeException(validationResult.Message);
        }

        Value = value;
    }

    private ValidationResult IsValid(double value)
    {
        if (!IsBiggerThanZero(value))
        {
            return ValidationResult.Failure("Score must be greater than 0");
        }
        
        return ValidationResult.Success();
    }

    private bool IsBiggerThanZero(double value)
    {
        return value > 0.0;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Score other) return false;
        return Value.Equals(other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}