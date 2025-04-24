using Microsoft.Extensions.DependencyInjection;
using QuizResultService.Application.Ports.Inbound.Admin;
using QuizResultService.Application.Ports.Inbound.Participant;
using QuizResultService.Application.Ports.Outbound;
using QuizResultService.Application.UseCases.Admin;
using QuizResultService.Application.UseCases.Participant;
using QuizResultService.Domain.Repositories;
using QuizResultService.Domain.Services.Impl;
using QuizResultService.Domain.Services.Interfaces;
using QuizResultService.Infrastructure.Repositories;
using QuizResultService.Infrastructure.Services;

namespace QuizResultService.Config.Wirings;

public static class QuizResultServiceWiring
{
    public static IServiceCollection AddQuizResultServiceWiring(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenService, JwtTokenServiceImpl>();
        services.AddScoped<IQuizResultService, QuizResultServiceImpl>();
        services.AddScoped<IQuizResultRepository, QuizResultRepositoryImpl>();
        services.AddScoped<IQuizResultQuestionRepository, QuizResultQuestionRepositoryImpl>();
        services.AddScoped<ICreateQuizResultUseCase, CreateQuizResultUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuizResultByQuizUseCase, GetPaginatedQuizResultByQuizUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuizResultByScheduleUseCase, GetPaginatedQuizResultByScheduleUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuizResultByStatusUseCase, GetPaginatedQuizResultByStatusUseCaseImpl>();
        services.AddScoped<IGradeQuizResultUseCase, GradeQuizResultUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuizResultByParticipantUseCase, GetPaginatedQuizResultByParticipantUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuestionByQuizUseCase, GetPaginatedQuestionByQuizUseCaseImpl>();
        
        return services;
    }
}