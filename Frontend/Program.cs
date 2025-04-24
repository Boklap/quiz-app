
    
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Frontend;
using Frontend.Handler;
using Frontend.Services;
using Frontend.Utilities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var authServiceClient = builder.Configuration["ApiBaseUrls:AuthServiceClient"];
var questionServiceClient = builder.Configuration["ApiBaseUrls:QuestionServiceClient"];
var quizServiceClient = builder.Configuration["ApiBaseUrls:QuizServiceClient"];
var scheduleServiceClient = builder.Configuration["ApiBaseUrls:ScheduleServiceClient"];
var quizResultServiceClient = builder.Configuration["ApiBaseUrls:QuizResultServiceClient"];

var authServiceApi = builder.Configuration["ApiNames:AuthServiceApi"];
var questionServiceApi = builder.Configuration["ApiNames:QuestionServiceApi"];
var quizApi = builder.Configuration["ApiNames:QuizApi"];
var scheduleApi = builder.Configuration["ApiNames:ScheduleApi"];
var quizResultApi = builder.Configuration["ApiNames:QuizResultApi"];

builder.Services.AddBlazoredToast();
builder.Services.AddAuthorizationCore();
builder.Services.AddTransient<JwtAuthorizationHandler>();
builder.Services.AddScoped<CookieHandler>();

builder.Services.AddHttpClient(authServiceApi, client =>
{
    client.BaseAddress = new Uri(authServiceClient);
}).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddHttpClient(questionServiceApi, client =>
{
    client.BaseAddress = new Uri(questionServiceClient);
}).AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient(quizApi, client =>
{
    client.BaseAddress = new Uri(quizServiceClient);
}).AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient(scheduleApi, client =>
{
    client.BaseAddress = new Uri(scheduleServiceClient);
}).AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddScoped<CookieService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped <QuestionService>();
builder.Services.AddScoped<QuizService>();
builder.Services.AddScoped<ScheduleService>();

await builder.Build().RunAsync();

