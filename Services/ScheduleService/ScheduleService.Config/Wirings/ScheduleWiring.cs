using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Application.Ports.Inbound;
using ScheduleService.Application.Ports.Outbound;
using ScheduleService.Application.UseCases;
using ScheduleService.Domain.Repositories;
using ScheduleService.Domain.Services.Impl;
using ScheduleService.Domain.Services.Interfaces;
using ScheduleService.Infrastructure.Adapters;
using ScheduleService.Infrastructure.Repositories;
using ScheduleService.Infrastructure.Services;

namespace ScheduleService.Config.Wirings;

public static class ScheduleWiring
{
    public static IServiceCollection AddScheduleWiring(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenService, JwtTokenServiceImpl>();
        services.AddScoped<IScheduleService, ScheduleServiceImpl>();
        services.AddScoped<IScheduleRepository, ScheduleRepositoryImpl>();
        services.AddScoped<ICreateScheduleUseCase, CreateScheduleUseCaseImpl>();
        services.AddScoped<IDeleteScheduleUseCase, DeleteScheduleUseCaseImpl>();
        services.AddScoped<IGetPaginatedScheduleByDateUseCase, GetPaginatedScheduleByDateUseCaseImpl>();
        services.AddScoped<IGetPaginatedScheduleByStatusUseCase, GetPaginatedScheduleByStatusUseCaseImpl>();
        services.AddScoped<IGetPaginatedScheduleUseCase, GetPaginatedScheduleUseCaseImpl>();
        services.AddScoped<IUpdateScheduleUseCase, UpdateScheduleUseCaseImpl>();
        services.AddScoped<IQuizService, QuizServiceImpl>();
        services.AddScoped<IGetQuizByScheduleUseCase, GetQuizByScheduleUseCaseImpl>();
        
        return services;
    }
}