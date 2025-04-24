using Microsoft.Extensions.DependencyInjection;
using QuizService.Application.Ports.Inbound.UseCases.DifficultyUseCases;
using QuizService.Application.UseCases.DifficultyUseCaseImpl;
using QuizService.Domain.Repositories;
using QuizService.Infrastructure.Repositories;

namespace QuizService.Config.Wirings;

public static class DifficultyServiceWiring
{
    public static IServiceCollection AddDifficultyServiceWiring(this IServiceCollection services)
    {
        services.AddScoped<IDifficultyRepository, DifficultyRepositoryImpl>();
        services.AddScoped<IGetDifficultiesUseCase, GetDifficultiesUseCaseImpl>();

        return services;
    }

}