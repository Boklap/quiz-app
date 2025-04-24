using ScheduleService.Shared;
using ScheduleService.Shared.Exceptions;

namespace ScheduleService.Domain.ValueObjects.Schedule;

public class MaxParticipant
{
    public int Value { get; }

    public MaxParticipant(int value)
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
            return ValidationResult.Failure("Min. 1");
        }

        return ValidationResult.Success();
    }

    private bool IsMoreThanZero(int value)
    {
        return value > 0;
    }
}