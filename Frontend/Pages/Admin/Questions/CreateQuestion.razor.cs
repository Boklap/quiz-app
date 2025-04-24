using System.Text.Json;
using Blazored.Toast.Services;
using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Frontend.Pages.Admin.Questions;

public partial class CreateQuestion : ComponentBase
{
    private bool _isLoading;
    [Inject] IToastService ToastService { get; set; }
    [Inject] QuestionService QuestionService { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }
    private List<CreateQuestionModel> _questions = new List<CreateQuestionModel>();
    private List<string> answerTypes = new List<string>();

    protected override async Task OnInitializedAsync()
    {
        await LoadAnswerTypesData();
    }

    private async Task LoadAnswerTypesData()
    {
        var response = await  QuestionService.GetQuestionAnswerTypes();
        
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        var contentString = await response.Content.ReadAsStringAsync();
        answerTypes = JsonSerializer.Deserialize<List<string>>(contentString);
    }
    
    private void AddQuestion()
    {
        _questions.Add(new CreateQuestionModel());
    }
    
    private void RemoveQuestion(int index)
    {
        if (index >= 0 && index < _questions.Count)
        {
            _questions.RemoveAt(index);
        }
    }
    
    private async Task HandleImageUpload(InputFileChangeEventArgs e, int index)
    {
        var file = e.File;

        if (file != null)
        {
            _questions[index].QuestionImage = file;
        }
    }
    
    private void AddAnswer(int questionIndex)
    {
        _questions[questionIndex].Answers.Add(new Answer());
    }

    private void RemoveAnswer(int questionIndex, int answerIndex)
    {
        if (_questions[questionIndex].Answers.Count > answerIndex)
        {
            _questions[questionIndex].Answers.RemoveAt(answerIndex);
        }
    }

    private async Task HandleAnswerImageUpload(InputFileChangeEventArgs e, int questionIndex, int answerIndex)
    {
        var file = e.File;

        if (file != null)
        {
            _questions[questionIndex].Answers[answerIndex].ImageFile = file;
        }
    }

    private void AddCorrectAnswerIndex(int questionIndex, int answerIndex)
    {
        if (_questions[questionIndex].CorrectAnswerIndex.Contains(answerIndex)) return;
        _questions[questionIndex].CorrectAnswerIndex.Add(answerIndex);
    }

    private async Task OnSubmit()
    {
        _isLoading = true;
        
        if (_questions.Count < 1)
        {
            ToastService.ShowError("Please select at least one question");
            _isLoading = false;
            return;
        }
        
        var response = await QuestionService.CreateQuestion(_questions);
        
        if (response.IsSuccessStatusCode)
        {
            ToastService.ShowSuccess("Question created");
        }

        else
        {
            ToastService.ShowError("Something went wrong");
        }
        
        _isLoading = false;
        Navigation.NavigateTo("/question");
    }
}