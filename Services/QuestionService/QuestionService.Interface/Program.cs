using QuestionService.Interface.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontend");
app.UseCors("AllowQuizBackend");

app.UseCustomMiddlewares();

app.MapCustomRoutes();

app.Run();