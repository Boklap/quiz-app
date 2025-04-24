using Microsoft.Extensions.DependencyInjection;
using QuestionService.Application.Ports.Inbound;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Application.Ports.Outbound;
using QuestionService.Application.UseCases;
using QuestionService.Domain.Repositories;
using QuestionService.Domain.Services.Impl;
using QuestionService.Domain.Services.Interfaces;
using QuestionService.Infrastructure.Repositories;
using QuestionService.Infrastructure.Services;

namespace QuestionService.Config.Wirings;

public static class QuestionServiceWiring
{
    public static IServiceCollection AddCreateQuestionWiring(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenService, JwtTokenServiceImpl>();
        services.AddScoped<IQuestionRepository, QuestionRepositoryImpl>();
        services.AddScoped<IQuestionService, QuestionServiceImpl>();
        services.AddScoped<IQuestionPublisher, QuestionPublisherImpl>();
        services.AddScoped<IQuestionConsumer, QuestionConsumerImpl>();
        services.AddScoped<IGetQuestionsbyQuestionIds, GetQuestionsByQuestionIdsImpl>();
        services.AddScoped<IRejectQuestionUseCase, RejectQuestionUseCaseImpl>();
        services.AddScoped<IFinalizeQuestionUseCase, FinalizeQuestionUseCaseImpl>();
        services.AddScoped<ICreateQuestionUseCase, CreateQuestionUseCaseImpl>();
        services.AddScoped<IDeleteQuestionUseCase, DeleteQuestionUseCaseImpl>();
        services.AddScoped<IGetPaginatedQuestionUseCase, GetPaginatedQuestionUseCaseImpl>();
        services.AddScoped<IGetQuestionByAdminUseCase, GetQuestionByAdminUseCaseImpl>();
        services.AddScoped<IGetQuestionByStatusUseCase, GetQuestionByStatusUseCaseImpl>();
        services.AddScoped<IGetQuestionById, GetQuestionByIdUseCaseImpl>();
        services.AddScoped<ISubmitQuestionToBeReviewed, SubmitQuestionToBeReviewedImpl>();
        services.AddScoped<IUpdateQuestionUseCase, UpdateQuestionUseCaseImpl>();

        services.AddScoped<IAnswerTypeRepository, AnswerTypeRepositoryImpl>();
        services.AddScoped<IGetAnswerTypesUseCase, GetAnswerTypeUseCaseImpl>();

        services.AddScoped<IQuestionStatusRepository, QuestionStatusRepositoryImpl>();
        services.AddScoped<IGetQuestionStatusUseCase, GetQuestionStatusUseCaseImpl>();
        
        return services;
    }
}