using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using UserService.Shared.Utilities;

namespace UserService.Infrastructure.Data;

public class UserServiceDbContextFactory : IDesignTimeDbContextFactory<UserServiceDbContext>
{
    public UserServiceDbContext CreateDbContext(string[] args)
    {
        EnvLoader.Load();
        
        var optionsBuilder = new DbContextOptionsBuilder<UserServiceDbContext>();
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        
        optionsBuilder.UseNpgsql(connectionString);
        return new UserServiceDbContext(optionsBuilder.Options);
    }
}