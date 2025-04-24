using QuizService.Interface.Middlewares;

namespace QuizService.Interface.Extensions;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
    {
        app.UseHttpsRedirection();
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseMiddleware<JwtReaderMiddleware>();
        
        return app;
    }
}