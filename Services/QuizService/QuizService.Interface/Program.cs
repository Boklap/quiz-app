using QuizService.Interface.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowFrontend");
app.UseCors("AllowScheduleBackend");

app.UseCustomMiddlewares();

app.MapCustomRoutes();

app.Run();