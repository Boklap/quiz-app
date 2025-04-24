using UserService.Shared;
using UserService.Shared.Exceptions;

namespace UserService.Domain.ValueObjects.User;

public class Dob
{
    public DateOnly Value { get; }

    public Dob()
    {
    }

    public Dob(DateOnly value)
    {
        var validationResult = IsValid(value);
        if (!validationResult.IsValid)
        {
            throw new InvalidAttributeException(validationResult.Message);
        }

        Value = value;
    }
    
    private ValidationResult IsValid(DateOnly value)
    {
        if (!IsMinimumAge(value))
        {
            return ValidationResult.Failure("Pengguna harus berusia minimal 6 tahun.");
        }

        return ValidationResult.Success();
    }

    private bool IsMinimumAge(DateOnly dob)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var age = today.Year - dob.Year;

        if (today < dob.AddYears(age))
        {
            age--;
        }

        return age >= 6;
    }
    
    public override string ToString() => Value.ToString("yyyy-MM-dd");

    public override bool Equals(object? obj)
    {
        if (obj is Dob other)
            return Value.Equals(other.Value);

        return false;
    }

    public override int GetHashCode() => Value.GetHashCode();
}