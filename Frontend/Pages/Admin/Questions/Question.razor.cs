using System.Text.Json;
using Frontend.Dto;
using Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages.Admin.Questions;

public partial class Question
{
    [Inject] NavigationManager Navigation { get; set; }
    [Inject] QuestionService QuestionService { get; set; }
    private List<string> questionStatus = new List<string>();
    private List<QuestionDto> questions = new List<QuestionDto>();
    private int currentPage = 1;
    private bool CanGoPrevious => currentPage > 1;
    private bool CanGoNext => questions != null! && questions.Count > 10;
    private bool _isLoading = true;

    private void onCreateButtonClick()
    {
        Navigation.NavigateTo("/create-question");
    }

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        await LoadQuestionStatus();
        await GetPaginatedQuestions();
        _isLoading = false;
    }

    private async Task LoadQuestionStatus()
    {
        questionStatus.Add("All");
        
        var response = await QuestionService.GetQuestionStatus();
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        var contentString = await response.Content.ReadAsStringAsync();
        questionStatus = JsonSerializer.Deserialize<List<string>>(contentString);
    }

    private async Task GetPaginatedQuestions()
    {
        var response = await QuestionService.GetPaginatedQuestion(currentPage, 10);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
        
        var contentString = await response.Content.ReadAsStringAsync();
        questions = JsonSerializer.Deserialize<List<QuestionDto>>(contentString);
    }

    private void OnQuestionClicked(string questionId)
    {
        Navigation.NavigateTo($"QuestionDetail/{questionId}");
    }
    
    private async Task PreviousPage()
    {
        if (CanGoPrevious)
        {
            currentPage--;
            await GetPaginatedQuestions();
        }
    }

    private async Task NextPage()
    {
        if (CanGoNext)
        {
            currentPage++;
            await GetPaginatedQuestions();
        }
    }

    private async Task OnSubmit(string questionId)
    {
        await QuestionService.SubmitQuestion(questionId);
    }

    private async Task OnDelete(string questionId)
    {
        await QuestionService.DeleteQuestion(questionId);
        questions = questions.Where(q => q.Id != questionId).ToList();
        StateHasChanged();
    }
}