using System.Net.Http.Json;
using Frontend.Dto;
using Frontend.Models;

namespace Frontend.Services;

public class QuizService
{
    private readonly HttpClient _client;

    public QuizService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("QuizAPI");
    }
    
    public async Task<HttpResponseMessage> FetchQuizzesAsync(int page, int pageSize)
    {
        return await _client.GetAsync($"/api/quiz/get/{page}/{pageSize}");
    }

    public async Task<HttpResponseMessage> SubmitQuiz(string quizId)
    {
        return await _client.PatchAsync($"/api/quiz/submit/{quizId}", null);
    }

    public async Task<HttpResponseMessage> DeleteQuiz(string quizId)
    {
        return await _client.PatchAsync($"/api/quiz/delete/{quizId}", null);
    }

    public async Task<HttpResponseMessage> GetTags()
    {
        return await _client.GetAsync("/api/tag/get");
    }

    public async Task<HttpResponseMessage> GetDifficulties()
    {
        return await _client.GetAsync("/api/difficulty/get");
    }

    public async Task<HttpResponseMessage> CreateQuiz(CreateQuizModel createQuizModel)
    {
        var payload = new
        {
            DifficultyId = createQuizModel.Difficulty,
            TagId = createQuizModel.Tag,
            Name = createQuizModel.Name,
            Description = createQuizModel.Description,
            MinimumGrade = createQuizModel.MinimumGrade,
            TestDuration = createQuizModel.TestDuration,
            TotalQuestion = 0
        };
        
        return await _client.PostAsJsonAsync("/api/quiz/create", payload);
    }

    public async Task<HttpResponseMessage> AddQuestionToQuiz(string quizId, List<string> selectedQuestionId)
    {
        var payload = new
        {
            QuizId = quizId,
            Questions = selectedQuestionId
        };
        
        return await _client.PostAsJsonAsync("/api/quizdetail/add/questions", payload);
    }

    public async Task<HttpResponseMessage> GetQuizById(string quizId)
    {
        return await _client.GetAsync($"/api/quiz/get/{quizId}");
    }

    public async Task<HttpResponseMessage> UpdateQuiz(QuizDto quizDto)
    {
        return await _client.PatchAsJsonAsync("/api/quiz/update", quizDto);
    }

    public async Task<HttpResponseMessage> GetSelectedQuestionByQuizId(string quizId)
    {
        return await _client.GetAsync($"/api/quizdetail/get/questions/{quizId}");
    }
}