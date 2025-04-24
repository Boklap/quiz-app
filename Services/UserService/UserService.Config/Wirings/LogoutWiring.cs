using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Ports.Inbound;
using UserService.Application.Ports.Outbound;
using UserService.Application.UseCases;
using UserService.Infrastructure.Services;

namespace UserService.Config.Wirings;

public static class LogoutWiring
{
    public static IServiceCollection AddLogoutWiring(this IServiceCollection services)
    {
        services.AddScoped<ICookieService, CookieServiceImpl>();
        services.AddScoped<ILogoutUseCase, LogoutUseCaseImpl>();

        return services;
    }
}