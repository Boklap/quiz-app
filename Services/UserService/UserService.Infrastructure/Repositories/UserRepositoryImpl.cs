using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public class UserRepositoryImpl : IUserRepository
{
    private readonly UserServiceDbContext _context;

    public UserRepositoryImpl(UserServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task InsertUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> FindUserByEmail(string email)
    {
        return await _context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Email.Value == email);
    }

    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserLastLogin(string id)
    {
        User user = (await _context.Users.FindAsync(id))!;
        user.LastLoginAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }
}