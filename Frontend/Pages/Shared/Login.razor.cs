using Frontend.Models;
using Frontend.Services;
using Frontend.Utilities;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages.Shared;

public partial class Login
{
    [Inject] private IConfiguration Configuration { get; set; }
    [Inject] private CookieService CookieService { get; set; }
    [Inject] private UserService UserService { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }
    private LoginModel _loginModel = new();
    private bool _isLoggingIn;
    private string _errorMessage = string.Empty;

    private async Task HandleLogin()
    {
        _isLoggingIn = true;
        var response = await UserService.LoginAsync(_loginModel);

        if (!response.IsSuccessStatusCode)
        {
            _errorMessage = "Login failed, please check your credentials.";
        }
        else
        {
            _errorMessage = string.Empty;
            string token = await CookieService.GetCookieAsync(Configuration["CookieName"]);
            var role = JwtUtil.GetRole(token);
            Navigation.NavigateTo("/home");
        }
        
        _isLoggingIn = false;
    }
}