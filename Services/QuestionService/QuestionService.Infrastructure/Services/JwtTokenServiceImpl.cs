using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using QuestionService.Application.Ports.Outbound;
using QuestionService.Shared.Exceptions;

namespace QuestionService.Infrastructure.Services;

public class JwtTokenServiceImpl : IJwtTokenService
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;

    public JwtTokenServiceImpl()
    {
        _secretKey = Environment.GetEnvironmentVariable("JWT_SECRET") 
                     ?? throw new EnvVariableEmptyException("JWT_SECRET environment variable is not set.");
        
        _issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") 
                  ?? throw new EnvVariableEmptyException("JWT_ISSUER environment variable is not set.");
        
        _audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") 
                    ?? throw new EnvVariableEmptyException("JWT_AUDIENCE environment variable is not set.");
    }
    
    public (string?, string?) GetUserIdAndRole(string token)
    {
        ClaimsPrincipal principal = VerifyAndReadToken(token);
        string? userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        string? role = principal.FindFirst(ClaimTypes.Role)?.Value;
        
        return (userId, role);
    }
    
    private ClaimsPrincipal VerifyAndReadToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_secretKey);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),

            ValidateIssuer = true,
            ValidIssuer = _issuer,

            ValidateAudience = true,
            ValidAudience = _audience,

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
        
        var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
        return principal;
    }
}