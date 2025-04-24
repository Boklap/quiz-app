using System.Text.Json;
using Blazored.Toast.Services;
using Frontend.Dto;
using Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages.Admin.Quiz;

public partial class AddQuestion : ComponentBase
{
    [Inject] private NavigationManager Navigation { get; set; }
    [Inject] IToastService Toast { get; set; }
    [Inject] QuestionService _questionService { get; set; }
    [Inject] QuizService _quizService { get; set; }
    [Parameter] public string quizId { get; set; }
    private List<QuestionDto> selectedQuestions { get; set; }
    private List<QuestionDto> questionToRemove { get; set; }
    private List<string> _selectedQuestionIds { get; set; }
    private int currentPage = 1;
    private bool _isLoading;
    private bool _isSave;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        
        questionToRemove = new List<QuestionDto>();
        selectedQuestions = new List<QuestionDto>();
        _selectedQuestionIds = new List<string>();

        await GetSelectedQuizQuestions();
        await GetPaginatedQuestions(currentPage, 10);

        _isLoading = false;
    }

    private async Task GetPaginatedQuestions(int page, int pageSize)
    {
        var response = await _questionService.GetPaginatedQuestion(page, pageSize);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
        
        var contentString = await response.Content.ReadAsStringAsync();
        var allQuestions = JsonSerializer.Deserialize<List<QuestionDto>>(contentString);

        var questions = allQuestions
            .Where(q => !_selectedQuestionIds.Contains(q.Id))
            .ToList();
        questionToRemove = questions;
    }

    private async Task GetSelectedQuizQuestions()
    {
        try
        {
            var response = await _quizService.GetSelectedQuestionByQuizId(quizId);
            if (!response.IsSuccessStatusCode)
            {
                Toast.ShowError($"Failed to get selected questions");
            }
            
            var contentString = await response.Content.ReadAsStringAsync();
            selectedQuestions = JsonSerializer.Deserialize<List<QuestionDto>>(contentString);
            _selectedQuestionIds.AddRange(selectedQuestions.Select(sq => sq.Id).ToList());
        }

        catch (Exception ex)
        {
            Toast.ShowError("Something went wrong");
        }
    }

    private void OnQustionAdded(string questionId)
    {
        if (!_selectedQuestionIds.Contains(questionId))
        {
            _selectedQuestionIds.Add(questionId);
            
            var selectedQuestion = questionToRemove.FirstOrDefault(q => q.Id == questionId);
            if (selectedQuestion != null)
            {
                questionToRemove.Remove(selectedQuestion);
                selectedQuestions.Add(selectedQuestion);
            }
        }
    }

    private void OnQustionRemoved(string questionId)
    {
        _selectedQuestionIds.Remove(questionId);
        var removedQuestion = selectedQuestions.FirstOrDefault(q => q.Id == questionId);

        if (removedQuestion != null)
        {
            selectedQuestions.Remove(removedQuestion);
            questionToRemove.Add(removedQuestion);
        }
    }
    
    private void OnQuizDetailClicked()
    {
        Navigation.NavigateTo($"/QuizDetail/{quizId}");
    }
    
    private async Task OnSaveClicked()
    {
        _isSave = true;
        
        try
        {
            var response = await _quizService.AddQuestionToQuiz(quizId, _selectedQuestionIds);
            if (!response.IsSuccessStatusCode)
            {
                Toast.ShowError("Failed to add question to quiz");
            }

            else
            {
                Toast.ShowSuccess("Question added to quiz");
            }
        }

        catch (Exception ex)
        {
            Toast.ShowError(ex.Message);
        }

        finally
        {
            _isSave = false;
        }
    }
}