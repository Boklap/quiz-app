using System.Text.RegularExpressions;
using UserService.Shared;
using UserService.Shared.Exceptions;

namespace UserService.Domain.ValueObjects.User;

public class Email
{
    public string Value { get; }

    private Email()
    {
    }

    public Email(string value)
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
            return ValidationResult.Failure("Email cannot be empty.");
        }

        if (!IsEndsWithCorrectDomain(value))
        {
            return ValidationResult.Failure("Email must be ends with @quiz.com.");
        }

        if (IsContainSpace(value))
        {
            return ValidationResult.Failure("Email cannot contains space.");
        }

        if (IsExceedLength(value))
        {
            return ValidationResult.Failure("Email cannot be more than 255 characters.");
        }

        if (!IsFormatCorrect(value))
        {
            return ValidationResult.Failure("Email format is invalid.");
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

    private bool IsContainSpace(string value)
    {
        return value.Contains(" ");
    }

    private bool IsEndsWithCorrectDomain(string value)
    {
        return value.EndsWith("@quiz.com");
    }

    private bool IsFormatCorrect(string value)
    {
        var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        return regex.IsMatch(value);
    }

    public override string ToString() => Value;

}