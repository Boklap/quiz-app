using System.Net.Http.Json;
using Frontend.Models;

namespace Frontend.Services;

public class UserService
{
    private readonly HttpClient _client;

    public UserService(IHttpClientFactory clientFactory)
    {
        
        _client = clientFactory.CreateClient("AuthAPI");
    }
    
    public async Task<HttpResponseMessage> LoginAsync(LoginModel model)
    {
        var payload = new
        {
            Email = model.Email,
            Password = model.Password
        };

        var response = await _client.PostAsJsonAsync("/api/auth/login", payload);
        return response;
    }

    public async Task<HttpResponseMessage> GetUsersAsync(int page, int pageSize)
    {
        return await _client.GetAsync($"/api/user/get/{page}/{pageSize}");
    }

    
}