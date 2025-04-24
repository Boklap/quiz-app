using Microsoft.Extensions.DependencyInjection;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Application.Ports.Outbound;
using QuizService.Application.UseCases.QuizUseCaseImpl;
using QuizService.Domain.Repositories;
using QuizService.Domain.Services.Impl;
using QuizService.Domain.Services.Interfaces;
using QuizService.Infrastructure.Repositories;
using QuizService.Infrastructure.Services;

namespace QuizService.Config.Wirings;

public static class QuizServiceWiring
{
    public static IServiceCollection AddQuizServiceWiring(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenService, JwtTokenServiceImpl>();
        services.AddScoped<IQuizService, QuizServiceImpl>();
        services.AddScoped<IQuizRepository, QuizRepositoryImpl>();
        services.AddScoped<ICreateQuizUseCase, CreateQuizUseCaseImpl>();
        services.AddScoped<IDeleteQuizUseCase, DeleteQuizUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuizByCreatorUseCase, GetPaginatedQuizByCreatorUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuizByStatusUseCase, GetPaginatedQuizByStatusUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuizByTagUseCase, GetPaginatedQuizByTagUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuizUseCase, GetPaginatedQuizUseCaseImpl>();
        services.AddScoped<ISubmitQuizToBeReviewed, SubmitQuizToBeReviewedImpl>();
        services.AddScoped<IRejectQuizUseCase, RejectQuizUseCaseImpl>();
        services.AddScoped<IFinalizeQuizUseCase, FinalizeQuizUseCaseImpl>();
        services.AddScoped<IUpdateQuizUseCase, UpdateQuizUseCaseImpl>();
        services.AddScoped<IGetQuizByIdUseCase, GetQuizByIdUseCaseImpl>();
        services.AddScoped<IGetQuizByDateUseCase, GetQuizByDateUseCaseImpl>();
        services.AddScoped<IGetQuizByQuizIds, GetQuizByQuizIdsUseCaseImpl>();

        return services;
    }
}