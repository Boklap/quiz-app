using QuestionService.Shared;
using QuestionService.Shared.Exceptions;

namespace QuestionService.Domain.ValueObjects.Question;

public class Point
{
    public double Value { get; set; }

    public Point(double value)
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
            return ValidationResult.Failure("Point must be bigger than zero");
        }
        
        return ValidationResult.Success();
    }

    private bool IsBiggerThanZero(double value)
    {
        return value > 0.0;
    }
}