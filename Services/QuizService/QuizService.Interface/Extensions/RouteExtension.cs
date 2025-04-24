namespace QuizService.Interface.Extensions;

public static class RouteExtension
{
    public static void MapCustomRoutes(this WebApplication app)
    {
        var apiGroup = app.MapGroup("/api");
        apiGroup.MapControllers();
    }
}