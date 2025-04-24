using System.Text.Json;
using Blazored.Toast.Services;
using Frontend.Dto;
using Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages.Admin.Schedule;

public partial class CreateSchedule : ComponentBase
{
    [Inject] QuizService QuizService { get; set; }
    [Inject] ScheduleService ScheduleService { get; set; }
    [Inject] NavigationManager Navigatino  { get; set; }
    [Inject] IToastService Toasts  { get; set; }
    private List<QuizDto> Quizzes { get; set; } = new List<QuizDto>();
    private CreateScheduleDto Schedule { get; set; } = new CreateScheduleDto();
    private int currentPage { get; set; } = 1;
    private bool CanNextPage => Quizzes.Count == 10;
    private bool CanPrevPage => currentPage > 1;
    private bool _isLoading;
    private bool _isSubmitting;
    
    private DateTime StartAt { get; set; } = DateTime.UtcNow.Date;
    private DateTime EndAt { get; set; } = DateTime.UtcNow.AddDays(1);
    private TimeOnly? StartAtTime { get; set; }
    private TimeOnly? EndAtTime { get; set; }

    private DateTime StartAtDate
    {
        get => StartAt.Date;
        set
        {
            var hours = StartAtTime.HasValue ? StartAtTime.Value.Hour : 0;
            var minutes = StartAtTime.HasValue ? StartAtTime.Value.Minute : 0;

            StartAt = new DateTime(value.Year, value.Month, value.Day, hours, minutes, 0, DateTimeKind.Utc);
        }
    }

    private DateTime EndAtDate
    {
        get => EndAt.Date;
        set
        {
            var hours = EndAtTime.HasValue ? EndAtTime.Value.Hour : 0;
            var minutes = EndAtTime.HasValue ? EndAtTime.Value.Minute : 0;

            EndAt = new DateTime(value.Year, value.Month, value.Day, hours, minutes, 0, DateTimeKind.Utc);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await GetPaginatedQuizzes();
    }

    private async Task GetPaginatedQuizzes()
    {
        _isLoading = true;
        try
        {
            var response = await QuizService.FetchQuizzesAsync(currentPage, 10);
            if (!response.IsSuccessStatusCode)
            {
                Toasts.ShowError("Failed to load quiz");
            }

            var contentString = await response.Content.ReadAsStringAsync();
            Quizzes = JsonSerializer.Deserialize<List<QuizDto>>(contentString);
        }

        catch (Exception ex)
        {
            Toasts.ShowError(ex.Message);
        }

        finally
        {
            _isLoading = false;
        }
    }
    
    private void SelectQuiz(string quizId)
    {
        Schedule.QuizId = quizId;
    }
    
    private void RemoveQuiz()
    {
        Schedule.QuizId = null!;
    }

    private async Task PrevPage()
    {
        if (CanPrevPage)
        {
            currentPage--;
            await GetPaginatedQuizzes();
        }
    }

    private async Task NextPage()
    {
        if (CanNextPage)
        {
            currentPage++;
            await GetPaginatedQuizzes();
        }
    }

    private async Task HandleSubmit()
    {
        if (string.IsNullOrEmpty(Schedule.QuizId))
        {
            Toasts.ShowWarning("Please select a quiz before submitting.");
            return;
        }

        var startTime = StartAtTime.HasValue ? StartAtTime.Value.ToTimeSpan() : TimeSpan.Zero;
        var endTime = EndAtTime.HasValue ? EndAtTime.Value.ToTimeSpan() : TimeSpan.Zero;

        Schedule.StartAt = new DateTime(
            StartAtDate.Year, 
            StartAtDate.Month, 
            StartAtDate.Day, 
            startTime.Hours, 
            startTime.Minutes, 
            startTime.Seconds, 
            DateTimeKind.Utc);

        Schedule.EndAt = new DateTime(
            EndAtDate.Year, 
            EndAtDate.Month, 
            EndAtDate.Day, 
            endTime.Hours, 
            endTime.Minutes, 
            endTime.Seconds, 
            DateTimeKind.Utc);
        
        if (Schedule.EndAt < Schedule.StartAt)
        {
            Toasts.ShowWarning("End time cannot be earlier than start time.");
            return;
        }

        var testDuration = Schedule.EndAt - Schedule.StartAt;
        if (testDuration.TotalMinutes <= 0)
        {
            Toasts.ShowWarning("Test duration must be greater than zero.");
            return;
        }

        try
        {
            _isSubmitting = true;
        
            var response = await ScheduleService.CreateSchedule(Schedule);
            var contentString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(contentString);
            if (response.IsSuccessStatusCode)
            {
                Toasts.ShowSuccess("Schedule created successfully!");
                Navigatino.NavigateTo("/schedule");
            }
            else
            {
                var err = await response.Content.ReadAsStringAsync();
                Toasts.ShowError($"Failed to create schedule: {err}");
            }
        }

        catch (Exception ex)
        {
            Toasts.ShowError(ex.Message);
        }

        finally
        {
            _isSubmitting = false;
        }
    }
}