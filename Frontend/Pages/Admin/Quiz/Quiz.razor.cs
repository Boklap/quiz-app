using System.Text.Json;
using Blazored.Toast;
using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Frontend.Dto;
using Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages.Admin.Quiz;

public partial class Quiz : ComponentBase
{
    [Inject] IToastService Toasts { get; set; }
    [Inject] QuizService QuizService { get; set; }
    [Inject] NavigationManager Navigation { get; set; }
    private List<QuizDto> quizzes = new List<QuizDto>();
    private List<string> quizStatuses = new List<string>();
    private bool _isLoading;
    private int currentPage = 1;
    private bool CanGoPrevious => currentPage > 1;
    private bool CanGoNext => quizzes != null && quizzes.Count > 10;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        await GetPaginatedQuizzes();
        _isLoading = false;
    }

    private async Task GetPaginatedQuizzes()
    {
        try
        {
            var response = await QuizService.FetchQuizzesAsync(currentPage, 10);
            if (!response.IsSuccessStatusCode)
            {
                Toasts.ShowError("Failed to load quiz");
            }

            var contentString = await response.Content.ReadAsStringAsync();
            quizzes = JsonSerializer.Deserialize<List<QuizDto>>(contentString);
        }

        catch (Exception ex)
        {
            Toasts.ShowError(ex.Message);
        }
    }

    private void OnQuizClicked(string quizId)
    {
        Navigation.NavigateTo($"/QuizDetail/{quizId}");
    }
    
    private async Task PreviousPage()
    {
        if (CanGoPrevious)
        {
            currentPage--;
            await GetPaginatedQuizzes();
        }
    }

    private async Task NextPage()
    {
        if (CanGoNext)
        {
            currentPage++;
            await GetPaginatedQuizzes();
        }
    }

    private async Task OnSubmit(string quizId)
    {
        var response = await QuizService.SubmitQuiz(quizId);

        if (!response.IsSuccessStatusCode)
        {
            Toasts.ShowError("Failed to submit quiz");
            return;
        }
        
        Toasts.ShowSuccess("Quiz submitted");
    }
    
    private async Task OnDelete(string quizId)
    {
        var response = await QuizService.DeleteQuiz(quizId);

        if (!response.IsSuccessStatusCode)
        {
            Toasts.ShowError("Failed to submit quiz");
            return;
        }
        
        Toasts.ShowSuccess("Quiz Deleted");
        quizzes = quizzes.Where(q => q.Id != quizId).ToList();
        StateHasChanged();
    }

    private void OnCreateButtonClick()
    {
        Navigation.NavigateTo("/create-quiz");
    }
}