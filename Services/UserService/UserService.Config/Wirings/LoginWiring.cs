using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Ports.Inbound;
using UserService.Application.Ports.Outbound;
using UserService.Application.UseCases;
using UserService.Domain.Repositories;
using UserService.Domain.Services.Interfaces;
using UserService.Infrastructure.Repositories;
using UserService.Infrastructure.Services;

namespace UserService.Config.Wirings;

public static class LoginWiring
{
    public static IServiceCollection AddLoginWiring(this IServiceCollection services)
    {
        services.AddScoped<ICookieService, CookieServiceImpl>();
        services.AddScoped<IPasswordHasher, PasswordHasherImpl>();
        services.AddScoped<IJwtTokenService, JwtTokenServiceImpl>();
        services.AddScoped<IUserRepository, UserRepositoryImpl>();
        services.AddScoped<ILoginUseCase, LoginUseCaseImpl>();

        return services;
    }
}