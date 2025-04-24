using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using ScheduleService.Application.Dtos;
using ScheduleService.Application.Ports.Outbound;
using ScheduleService.Shared.Exceptions;

namespace ScheduleService.Infrastructure.Adapters;

public class QuizServiceImpl : IQuizService
{
    private readonly string? _quizApiUrl;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IHttpClientFactory _client;
    
    public QuizServiceImpl(IHttpContextAccessor httpContextAccessor, IHttpClientFactory client)
    {
        _httpContextAccessor = httpContextAccessor;
        _client = client;
        _quizApiUrl = Environment.GetEnvironmentVariable("QUIZ_API_URL");
    }


    public async Task<List<QuizDto>> GetQuizBySchedule(DateTime startAt, DateTime endAt)
    {
        if (_quizApiUrl == null)
        {
            throw new EnvVariableEmptyException("Quiz Env is empty");
        }
        
        var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var client = _client.CreateClient();
        string formattedStart = startAt.ToString("o");
        string formattedEnd = endAt.ToString("o");
        var url = $"{_quizApiUrl}?startAt={formattedStart}&endAt={formattedEnd}";
    
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", token);
    
        var response = await client.SendAsync(request);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new ApiServiceFailException("Data not found");
        }
        
        var responseStream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<List<QuizDto>>(responseStream);
    
        return result!;
    }

    public async Task<List<QuizDto>> GetQuizByIds(List<string> quizIds)
    {
        if (_quizApiUrl == null)
        {
            throw new EnvVariableEmptyException("Quiz Env is empty");
        }
        
        var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var client = _client.CreateClient();
    
        var content = new StringContent(JsonSerializer.Serialize(quizIds), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, _quizApiUrl)
        {
            Content = content
        };

        request.Headers.Add("Authorization", token);

        var response = await client.SendAsync(request);
    
        if (!response.IsSuccessStatusCode)
        {
            throw new ApiServiceFailException("Data not found");
        }
    
        var responseStream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<List<QuizDto>>(responseStream);

        return result!;
    }

}