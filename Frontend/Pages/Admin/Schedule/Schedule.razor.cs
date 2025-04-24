using System.Text.Json;
using Blazored.Toast.Services;
using Frontend.Dto;
using Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages.Admin.Schedule;

public partial class Schedule : ComponentBase
{
    [Inject] NavigationManager Navigate { get; set; }
    [Inject] IToastService ToastService { get; set; }
    [Inject] ScheduleService ScheduleService { get; set; }
    private List<QuizDto> quizzes { get; set; } = new List<QuizDto>();
    private bool _isLoading;
    
    private DateTime _startDate = DateTime.UtcNow.Date;
    private DateTime _endDate = DateTime.UtcNow.Date.AddDays(1);

    private DateTime startDate
    {
        get => _startDate;
        set => _startDate = DateTime.SpecifyKind(value, DateTimeKind.Utc).ToUniversalTime();
    }

    private DateTime endDate
    {
        get => _endDate;
        set => _endDate = DateTime.SpecifyKind(value, DateTimeKind.Utc).ToUniversalTime();
    }

    protected override async Task OnInitializedAsync()
    {
        await FetchQuizSchedule();
    }

    private async Task FetchQuizSchedule()
    {
        _isLoading = true;
        try
        {
            var response = await ScheduleService.FetchQuizBySchedule(_startDate, _endDate);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                ToastService.ShowError(response.Content.ReadAsStringAsync().Result);
                quizzes = new List<QuizDto>();
                return;
            }

            quizzes = JsonSerializer.Deserialize<List<QuizDto>>(responseString);
        }

        catch (Exception ex)
        {
            ToastService.ShowError(ex.Message);
        }

        finally
        {
            _isLoading = false;
        }
    }

    private void OnCreateButtonClicked()
    {
        Navigate.NavigateTo("/create-schedule");
    }

}