using UserService.Domain.Entities;

namespace UserService.Application.Ports.Inbound;

public interface IGetPaginatedUserUseCase
{
    Task<List<User>?> Execute();
}