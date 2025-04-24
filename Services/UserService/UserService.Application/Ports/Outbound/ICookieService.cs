namespace UserService.Application.Ports.Outbound;

public interface ICookieService
{
    void SetCookie(string key, string value, DateTime expiresAt);
    string GetCookie(string key);
    void DeleteCookie(string key);
}