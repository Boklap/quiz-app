using Microsoft.AspNetCore.Authentication.Cookies;
using UserService.Config.DbConnections;
using UserService.Config.Wirings;
using UserService.Interface.Middlewares;
using UserService.Shared.Utilities;

EnvLoader.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.WebHost.UseUrls("http://localhost:5079", "https://localhost:7170");
builder.Services.AddOpenApi();
builder.Services.AddHttpContextAccessor();
builder.Services.AddPostgresDbConnection();
builder.Services.AddRegisterWiring();
builder.Services.AddLoginWiring();
builder.Services.AddLogoutWiring();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:5057");
    });
});

var app = builder.Build();
RouteGroupBuilder apiGroup = app.MapGroup("/api");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");
app.UseMiddleware<ExceptionHandlingMiddleware>();

apiGroup.MapControllers();

app.Run();