using QuestionService.Interface.Middlewares;

namespace QuestionService.Interface.Extensions;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseMiddleware<JwtReaderMiddleware>();
        
        return app;
    }
}