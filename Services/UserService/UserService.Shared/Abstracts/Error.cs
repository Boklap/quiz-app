namespace UserService.Shared.Abstracts;

public class Error(string message, int statusCode) : Exception(message)
{
    public override string Message { get; } = message;
    public int StatusCode { get; } = statusCode;
}