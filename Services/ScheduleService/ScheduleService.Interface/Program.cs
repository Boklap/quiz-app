using ScheduleService.Config.DbConnections;
using ScheduleService.Interface.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontend");

app.UseCustomMiddlewares();

app.MapCustomRoutes();

app.Run();
