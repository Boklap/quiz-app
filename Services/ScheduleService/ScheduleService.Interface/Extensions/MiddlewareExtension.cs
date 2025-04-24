using ScheduleService.Interface.Middlewares;

namespace ScheduleService.Interface.Extensions;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
    {
        app.UseHttpsRedirection();
        app.UseMiddleware<ExceptionHandling>();
        app.UseMiddleware<JwtReader>();
        
        return app;
    }
}