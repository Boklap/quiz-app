using UserService.Domain.Entities;

namespace UserService.Domain.Repositories;

public interface IRoleRepository
{
    Task<Role?> FindRoleById(string roleId);
}