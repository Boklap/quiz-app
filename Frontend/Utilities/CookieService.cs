using Microsoft.JSInterop;

namespace Frontend.Utilities;

public class CookieService
{
    private readonly IJSRuntime _jsRuntime;

    public CookieService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string> GetCookieAsync(string cookieName)
    {
        return await _jsRuntime.InvokeAsync<string>("getCookie", cookieName);
    }
}