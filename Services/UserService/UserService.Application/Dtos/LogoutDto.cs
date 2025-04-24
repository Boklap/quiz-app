namespace UserService.Application.Dtos;

public class LogoutDto(string token)
{
    public string Token { get; set; } = token;
}