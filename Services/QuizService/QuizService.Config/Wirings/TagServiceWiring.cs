using Microsoft.Extensions.DependencyInjection;
using QuizService.Application.Ports.Inbound.UseCases.TagUseCases;
using QuizService.Application.UseCases.TagUseCaseImpl;
using QuizService.Domain.Repositories;
using QuizService.Infrastructure.Repositories;

namespace QuizService.Config.Wirings;

public static class TagServiceWiring
{
    public static IServiceCollection AddTagServiceWiring(this IServiceCollection services)
    {
        services.AddScoped<ITagRepository, TagRepositoryImpl>();
        services.AddScoped<IGetTagUseCase, GetTagUseCaseImpl>();

        return services;
    }
}