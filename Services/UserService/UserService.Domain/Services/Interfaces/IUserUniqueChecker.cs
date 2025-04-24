namespace UserService.Domain.Services.Interfaces;

public interface IUserUniqueChecker
{
    public Task<bool> IsUserUnique(string email);
}