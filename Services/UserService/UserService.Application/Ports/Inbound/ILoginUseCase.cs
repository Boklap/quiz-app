using UserService.Application.Dtos;
using UserService.Domain.Entities;

namespace UserService.Application.Ports.Inbound;

public interface ILoginUseCase
{
    public Task Execute(LoginDto loginDto);
    public Task<User?> GetUserByEmail(string email);
    public bool ValidateCredentials(string dtoPassword, string password);
    public string GenerateJwtToken(User loginDto);
}