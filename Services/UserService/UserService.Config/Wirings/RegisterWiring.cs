using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Ports.Inbound;
using UserService.Application.UseCases;
using UserService.Domain.Repositories;
using UserService.Domain.Services;
using UserService.Domain.Services.Impl;
using UserService.Domain.Services.Interfaces;
using UserService.Infrastructure.Repositories;
using UserService.Infrastructure.Services;

namespace UserService.Config.Wirings;

public static class RegisterWiring
{
    public static IServiceCollection AddRegisterWiring(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepositoryImpl>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserUniqueChecker, UserUniqueCheckerImpl>();
        services.AddScoped<IPasswordHasher, PasswordHasherImpl>();
        services.AddTransient<UserFactory>();
        services.AddScoped<IRegisterUseCase, RegisterUseCaseImpl>();

        return services;
    }
}