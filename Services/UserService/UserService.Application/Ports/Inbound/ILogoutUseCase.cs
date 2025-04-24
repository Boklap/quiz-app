namespace UserService.Application.Ports.Inbound;

public interface ILogoutUseCase
{
    public Task Execute(string key);
}