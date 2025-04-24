using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UserService.Application.Ports.Outbound;
using UserService.Domain.Entities;
using UserService.Shared.Exceptions;

namespace UserService.Infrastructure.Services;

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
    
    public string GenerateToken(User user)
    {
        var userRoles = user.UserRoles
            .Select(ur => ur.Role.Name)
            .ToList();
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, string.Join(",", userRoles))
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string? GetUserId(string token)
    {
        ClaimsPrincipal principal = VerifyAndReadToken(token);
        return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public string? GetUserRole(string token)
    {
        ClaimsPrincipal principal = VerifyAndReadToken(token);
        return principal.FindFirst(ClaimTypes.Role)?.Value;
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