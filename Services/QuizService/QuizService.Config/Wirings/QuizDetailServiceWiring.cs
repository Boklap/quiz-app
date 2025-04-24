using Microsoft.Extensions.DependencyInjection;
using QuizService.Application.Ports.Inbound.UseCases.QuizDetailUseCases;
using QuizService.Application.Ports.Outbound.Api;
using QuizService.Application.UseCases.QuizDetailUseCaseImpl;
using QuizService.Domain.Repositories;
using QuizService.Infrastructure.Adapters;
using QuizService.Infrastructure.Repositories;

namespace QuizService.Config.Wirings;

public static class QuizDetailServiceWiring
{
    public static IServiceCollection AddQuizDetailServiceWiring(this IServiceCollection services)
    {
        services.AddHttpClient<IQuestionService, QuestionServiceImpl>();
        services.AddScoped<IQuizDetailRepository, QuizDetailRepositoryImpl>();
        services.AddScoped<IGetQuestionsByQuizIdUseCase, GetQuestionsByQuizIdUseCaseImpl>();
        services.AddScoped<IAddQuestionToQuizDetailUseCase, AddQuestionToQuizDetailUseCaseImpl>();

        return services;
    }
} 