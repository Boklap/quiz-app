using ScheduleService.Shared.Abstracts;

namespace ScheduleService.Interface.Middlewares;

public class ExceptionHandling
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandling> _logger;

    public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }

        catch (Error error)
        {
            _logger.LogError(error.Message);
            await WriteErrorResponse(context, error);
        }

        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            await WriteErrorResponse(context, 500, "Internal Server Error");
        }
    }
    
    private async Task WriteErrorResponse(HttpContext context, Error error)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = error.StatusCode;
        await context.Response.WriteAsJsonAsync(new { error.Message });
    }
    
    private async Task WriteErrorResponse(HttpContext context, int statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(new { message });
    }
}