using System.Text.Json;
using Blazored.Toast.Services;
using Frontend.Dto;
using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Frontend.Pages.Admin.Questions;

public partial class QuestionDetail : ComponentBase
{
    [Inject] IToastService ToastService { get; set; }
    [Inject] private QuestionService QuestionService { get; set; }
    [Parameter] public string questionId { get; set; }
    
    private QuestionDto _question = null!;
    private List<string> answerTypes = new List<string>();
    private bool _isLoading;
    private bool _isUpdating;
    
    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        await GetQuestionDetail();
        await LoadAnswerTypesData();
        _isLoading = false;
    }
    
    public async Task LoadAnswerTypesData()
    {
        var response = await  QuestionService.GetQuestionAnswerTypes();
        
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        var contentString = await response.Content.ReadAsStringAsync();
        answerTypes = JsonSerializer.Deserialize<List<string>>(contentString);
    }

    private async Task GetQuestionDetail()
    {
        Console.WriteLine($"ID: {questionId}");
        var response = await  QuestionService.GetQuestionById(questionId);
        if (!response.IsSuccessStatusCode)
        {
            ToastService.ShowError($"Failed to fetch question");
            return;
        }
        
        var contentString = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(contentString))
        {
            ToastService.ShowWarning("No data returned for this question.");
            return;
        }

        try
        {
            var question = JsonSerializer.Deserialize<QuestionDto>(contentString);
            if (question == null)
            {
                ToastService.ShowWarning("Question not found.");
                return;
            }
            
            _question = question;
            _question.AnswerList = new List<Answer>();

            for(int i = 0; i < _question.Answers.Count; i++)
            {
                if (_question.CorrectAnswerIndex != null && i == _question.CorrectAnswerIndex[0])
                {
                    _question.AnswerList.Add(new Answer()
                    {
                        ImageFile = null,
                        IsSelected = true,
                        Text = _question.Answers[i],
                    });
                    
                    continue;
                }
                
                _question.AnswerList.Add(new Answer()
                {
                    ImageFile = null,
                    IsSelected = false,
                    Text = _question.Answers[i],
                });
            }
        }
        catch (Exception ex)
        {
            ToastService.ShowError("Failed to parse question data.");
            Console.WriteLine(ex);
        }
    }
    
    private async Task HandleImageUpload(InputFileChangeEventArgs e)
    {
        var file = e.File;

        if (file != null)
        {
            _question.QuestionImageFile = file;
        }
    }
    
    private void AddAnswer()
    {
        _question.AnswerList.Add(new Answer());
    }

    private void RemoveAnswer(int answerIndex)
    {
        if (_question.AnswerList.Count > answerIndex)
        {
            _question.AnswerList.RemoveAt(answerIndex); 
        }
    }

    private void HandleAnswerImageUpload(InputFileChangeEventArgs e, int answerIndex)
    {
        var file = e.File;

        if (file != null)
        {
            _question.AnswerList[answerIndex].ImageFile = file;
            _question.Answers[answerIndex] = file.Name;
        }
    }
    
    private void AddCorrectAnswerIndex(int answerIndex)
    {
        if (_question.CorrectAnswerIndex.Contains(answerIndex)) return;
        _question.CorrectAnswerIndex.Clear();
        _question.CorrectAnswerIndex.Add(answerIndex);
    }

    private async Task OnSubmit()
    {
        _isUpdating = true;
        var response = await QuestionService.UpdateQuestion(_question);
        
        if (!response.IsSuccessStatusCode) ToastService.ShowError("Failed to update question");
        else ToastService.ShowSuccess($"Question updated");
        
        _isUpdating = false;
    }
}