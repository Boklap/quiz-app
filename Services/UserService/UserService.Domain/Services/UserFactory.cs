using UserService.Domain.Entities;
using UserService.Domain.Services.Interfaces;
using UserService.Domain.ValueObjects.User;

namespace UserService.Domain.Services;

public class UserFactory
{
    private readonly IPasswordHasher _passwordHasher;

    public UserFactory(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public User CreateUser(string usernameStr, string emailStr, string passwordStr, DateOnly dobDate)
    {
        string id = GenerateId();
        Username username = new Username(usernameStr);
        Email email = new Email(emailStr);
        Password password = new Password(passwordStr);
        string hash = _passwordHasher.Hash(passwordStr);
        Password hashedPassword = Password.CreateHashed(hash);
        Dob dob = new Dob(dobDate);

        return new User(
            id, username, email, hashedPassword, dob
        );
    }

    private string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }
}