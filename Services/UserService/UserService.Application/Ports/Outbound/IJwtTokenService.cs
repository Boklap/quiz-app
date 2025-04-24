using System.Security.Claims;
using UserService.Domain.Entities;

namespace UserService.Application.Ports.Outbound;

public interface IJwtTokenService
{
    string GenerateToken(User user);
    string? GetUserId(string token);
    string? GetUserRole(string token);
}