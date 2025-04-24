using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using UserService.Application.Ports.Outbound;

namespace UserService.Infrastructure.Services;

public class CookieServiceImpl : ICookieService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieServiceImpl(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public void SetCookie(string key, string value, DateTime expiresAt)
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Append(
            key,
            value,
            new CookieOptions
            {
                Expires = expiresAt,
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None
            });
    }

    public string GetCookie(string key)
    {
        return _httpContextAccessor.HttpContext.Request.Cookies[key];
    }

    public void DeleteCookie(string key)
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
    }
}