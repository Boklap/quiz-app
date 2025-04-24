using System.Text.Json;
using Blazored.Toast.Services;
using Frontend.Dto;
using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages.Admin.Quiz;

public partial class QuizDetail : ComponentBase
{
    [Parameter] public string quizId { get; set; }
    [Inject] private QuizService QuizService { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }
    [Inject] IToastService ToastService { get; set; }
    private QuizDto _quiz { get; set; } = new QuizDto();
    private Dictionary<string, string> TagList = new();
    private Dictionary<string, string> DifficultyList = new();
    private bool _isLoading;
    private bool _isSubmitting;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        await LoadQuizDetail();
        await GetTags();
        await GetDifficulties();
        _isLoading = false;
    }

    private async Task LoadQuizDetail()
    {
        try
        {
            _isLoading = true;
            var response = await QuizService.GetQuizById(quizId);

            string contentString = await response.Content.ReadAsStringAsync();
            _quiz = JsonSerializer.Deserialize<QuizDto>(contentString);

            _isLoading = false;
        }

        catch (Exception ex)
        {
            ToastService.ShowError($"Error loading Quiz: {ex.Message}");
        }

        finally
        {
            _isLoading = false;
        }
        
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
        try
        {
            _isSubmitting = true;
            var response = await QuizService.UpdateQuiz(_quiz);
            if (!response.IsSuccessStatusCode)
            {
                ToastService.ShowError("Failed to update quiz");
            }
            
            else ToastService.ShowSuccess($"Updated Quiz: {_quiz.Id}");
        }

        catch (Exception ex)
        {
            ToastService.ShowError($"Error submitting quiz: {ex.Message}");
        }

        finally
        {
            _isSubmitting = false;
        }
        
    }

    private void OnManageQuestionClicked()
    {
        Navigation.NavigateTo($"/AddQuestion/{quizId}");
    }
}