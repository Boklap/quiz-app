using UserService.Application.Dtos;
using UserService.Domain.Entities;

namespace UserService.Application.Ports.Inbound;

public interface IRegisterUseCase
{
    public Task Execute(RegisterDto registerDto);
    public Task<bool> IsUserUnique(string email);
    public Task<User> CreateUser(RegisterDto registerDto);
    public Task RegisterUser(User user);
}