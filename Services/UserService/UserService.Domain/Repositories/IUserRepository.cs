using UserService.Domain.Entities;

namespace UserService.Domain.Repositories;

public interface IUserRepository
{
    public Task InsertUser(User user);
    public Task<User?> FindUserByEmail(string email);
    public Task UpdateUser(User user);
    public Task UpdateUserLastLogin(string id);
}