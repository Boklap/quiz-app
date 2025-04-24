using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace Frontend.Utilities
{
    public class JwtUtil
    {
        public static Dictionary<string, string> DecodeJwt(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var claims = jwtToken.Claims.ToDictionary(c => c.Type, c => c.Value);
            return claims;
        }
        
        public static string? GetRole(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            return jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("role"))?.Value;
        }

        public static string? GetUsername(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            return jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("name"))?.Value;
        }

        public static string? GetUserId(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            return jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("nameidentifier"))?.Value;
        }
    }
    
}