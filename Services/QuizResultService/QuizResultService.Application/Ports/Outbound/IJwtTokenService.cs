namespace QuizResultService.Application.Ports.Outbound;

public interface IJwtTokenService
{
    (string?, string?) GetUserIdAndRole(string token);
}