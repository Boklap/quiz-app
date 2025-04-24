using UserService.Application.Ports.Inbound;
using UserService.Domain.Entities;

namespace UserService.Application.UseCases;

public class GetPaginatedUserUseCaseImpl : IGetPaginatedUserUseCase
{
    public Task<List<User>?> Execute()
    {
        throw new NotImplementedException();
    }
}