namespace UserService.Application.Dtos;

public class LoginDto(string email, string password)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}