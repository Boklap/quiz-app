using QuestionService.Application.Ports.Outbound;

namespace QuestionService.Interface.Middlewares;

public class JwtReaderMiddleware
{
    private readonly RequestDelegate _next;

    public JwtReaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string? token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Authorization token is required");
            return;
        }

        var jwtTokenService = context.RequestServices.GetRequiredService<IJwtTokenService>();
        (string? userId, string? role) userInfo = jwtTokenService.GetUserIdAndRole(token);
        
        context.Items["UserId"] = userInfo.userId;
        context.Items["Role"] = userInfo.role;
        await _next(context);
    }
}