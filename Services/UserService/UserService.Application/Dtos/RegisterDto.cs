namespace UserService.Application.Dtos;

public class RegisterDto(string username, string email, string password, DateOnly dob)
{
    public string Username { get; set; } = username;
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
    public DateOnly Dob { get; set; } = dob;
}