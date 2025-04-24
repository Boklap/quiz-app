namespace QuestionService.Application.Ports.Outbound;

public interface IJwtTokenService
{
    (string?, string?) GetUserIdAndRole(string token);
}