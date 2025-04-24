using System.Security.Cryptography;
using System.Text;
using UserService.Domain.Services.Interfaces;

namespace UserService.Infrastructure.Services;

public class PasswordHasherImpl : IPasswordHasher
{
    public string Hash(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                
            StringBuilder builder = new StringBuilder();
            foreach (var byteVal in bytes)
            {
                builder.Append(byteVal.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public bool Verify(string plainPassword, string hashedPassword)
    {
        string hashedInputPassword = Hash(plainPassword);
        return hashedInputPassword.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);
    }
}