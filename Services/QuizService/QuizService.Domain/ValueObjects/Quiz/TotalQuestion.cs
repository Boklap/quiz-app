using QuizService.Shared;
using QuizService.Shared.Exceptions;

namespace QuizService.Domain.ValueObjects.Quiz;

public class TotalQuestion
{
    public int Value { get; }

    public TotalQuestion(int value)
    {
        Value = value;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is TotalQuestion other)
            return Value == other.Value;
    
        return false;
    }
    
    public override int GetHashCode() => Value.GetHashCode();
}