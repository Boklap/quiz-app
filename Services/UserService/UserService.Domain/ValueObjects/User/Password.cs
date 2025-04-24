using System.Text.RegularExpressions;
using UserService.Shared;
using UserService.Shared.Exceptions;

namespace UserService.Domain.ValueObjects.User;

public class Password
{
    public string Value { get; }

    public Password()
    {
    }
    
    public Password(string value, bool validatePassword = true)
    {
        if (validatePassword)
        {
            ValidationResult validationResult = IsValid(value);
            if (!validationResult.IsValid)
            {
                throw new InvalidAttributeException(validationResult.Message);
            }
        }
        
        Value = value;
    }

    public static Password CreateHashed(string value)
    {
        return new Password(value, false);
    }

    private ValidationResult IsValid(string value)
    {
        if (!HasMinimumLength(value))
        {
            return ValidationResult.Failure("Password must contain at least 8 characters.");
        }
        
        if (!IsContainNumber(value))
        {
            return ValidationResult.Failure("Password must contains at least 1 number.");
        }

        if (!IsContainSymbol(value))
        {
            return ValidationResult.Failure("Password must contains at least 1 symbol.");
        }

        return ValidationResult.Success();
    }
    
    private bool HasMinimumLength(string value) => value.Length >= 8;

    private bool IsContainNumber(string value) => Regex.IsMatch(value, @"\d");

    private bool IsContainSymbol(string value) => Regex.IsMatch(value, @"[\W_]+");
    
    public override string ToString() => Value;
    
    public override bool Equals(object? obj)
    {
        if (obj is Password other)
            return Value.Equals(other.Value, StringComparison.Ordinal);
    
        return false;
    }
    
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);
}