using UserService.Domain.Entities;
using UserService.Domain.Repositories;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly UserServiceDbContext _context;

    public RoleRepository(UserServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task<Role?> FindRoleById(string roleId)
    {
        return await _context.Roles.FindAsync(roleId); 
    }
}