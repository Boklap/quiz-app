using System.Text.Json;
using Blazored.Toast.Services;
using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages.Admin.Quiz;

public partial class CreateQuiz : ComponentBase
{
    [Inject] NavigationManager Navigation { get; set; }
    [Inject] IToastService ToastService { get; set; }
    [Inject] QuizService QuizService { get; set; }
    private CreateQuizModel _model = new();
    private Dictionary<string, string> TagList = new();
    private Dictionary<string, string> DifficultyList = new();
    private bool _isLoading;
    private bool _isSubmitting;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        await GetTags();
        await GetDifficulties();
        _isLoading = false;
    }

    private async Task GetTags()
    {
        var response = await QuizService.GetTags();
        if (!response.IsSuccessStatusCode)
        {
            ToastService.ShowError("Failed to get tags");
        }
        
        var contentString = await response.Content.ReadAsStringAsync();
        List<Tag> tags = JsonSerializer.Deserialize<List<Tag>>(contentString);

        if (tags != null)
        {
            TagList = tags.ToDictionary(x => x.Id, x => x.Name);
        }
    }

    private async Task GetDifficulties()
    {
        var response = await QuizService.GetDifficulties();
        if (!response.IsSuccessStatusCode)
        {
            ToastService.ShowError("Failed to get difficulties");
        }
        
        
        var contentString = await response.Content.ReadAsStringAsync();
        List<Difficulty> difficulties = JsonSerializer.Deserialize<List<Difficulty>>(contentString);

        if (difficulties != null)
        {
            DifficultyList = difficulties.ToDictionary(x => x.Id, x => x.Name);
        }
    }

    private async Task OnSubmit()
    {
        _isSubmitting = true;
        var respone = await QuizService.CreateQuiz(_model);
        if (!respone.IsSuccessStatusCode)
        {
            ToastService.ShowError("Failed to create quiz");
            _isSubmitting = false;
            return;
        }
        
        var contentString = await respone.Content.ReadAsStringAsync();
        Console.WriteLine($"Content string stinrg stinrg sitnr gsitng: {contentString}");
        string quizId = JsonSerializer.Deserialize<string>("\"" + contentString + "\"");
        
        ToastService.ShowSuccess("Created quiz");
        _isSubmitting = false;
        Navigation.NavigateTo($"/AddQuestion/{quizId}");
    }
}