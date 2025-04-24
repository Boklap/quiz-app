using System.Net.Http.Json;
using Frontend.Dto;

namespace Frontend.Services;

public class ScheduleService
{
    private readonly HttpClient _client;
    
    public ScheduleService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("ScheduleAPI");
    }

    public async Task<HttpResponseMessage> FetchQuizBySchedule(DateTime startDate, DateTime endDate)
    {
        var formattedStart = Uri.EscapeDataString(startDate.ToString("o"));
        var formattedEnd = Uri.EscapeDataString(endDate.ToString("o"));

        var url = $"/api/schedule/get/quiz?startAt={formattedStart}&endAt={formattedEnd}";
        return await _client.GetAsync(url);
    }

    public async Task<HttpResponseMessage> CreateSchedule(CreateScheduleDto createScheduleDto)
    {
        return await _client.PostAsJsonAsync("/api/schedule/create", createScheduleDto);
    }

}