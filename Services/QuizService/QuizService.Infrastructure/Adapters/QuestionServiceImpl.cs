using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using QuizService.Application.Ports.Outbound.Api;
using QuizService.Domain.ValueObjects.FinalizedQuizDetail;
using QuizService.Shared.Exceptions;

namespace QuizService.Infrastructure.Adapters;

public class QuestionServiceImpl : IQuestionService
{
    private readonly HttpClient _http;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string? _getQuestionApi;

    public QuestionServiceImpl(HttpClient http, IHttpContextAccessor httpContextAccessor, IHttpClientFactory clientFactory
    )
    {
        _getQuestionApi = Environment.GetEnvironmentVariable("FETCH_QUESTIONS_API");
        _http = http;
        _httpContextAccessor = httpContextAccessor;
        _httpClientFactory = clientFactory;
    }
    
    public async Task<List<Question>?> GetQuestionsByids(List<string> questionIds)
    {
        if (_getQuestionApi == null)
        {
            throw new EnvVariableEmptyException("Api is not set");
        }
        
        var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        
        var request = new HttpRequestMessage(HttpMethod.Post, _getQuestionApi)
        {
            Content = JsonContent.Create(questionIds)
        };
        request.Headers.Add("Authorization", token);
        
        var client = _httpClientFactory.CreateClient();
        var response = await client.SendAsync(request);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new ApiServiceFailException("Data not found");
        }
        
        var questions = await response.Content.ReadFromJsonAsync<List<Question>>();
        return questions;
    }
}