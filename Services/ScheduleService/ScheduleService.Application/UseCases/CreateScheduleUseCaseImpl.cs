using Microsoft.AspNetCore.Http;
using ScheduleService.Application.Dtos;
using ScheduleService.Application.Ports.Inbound;
using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;
using ScheduleService.Domain.Services.Interfaces;
using ScheduleService.Shared.Exceptions;

namespace ScheduleService.Application.UseCases;

public class CreateScheduleUseCaseImpl : ICreateScheduleUseCase
{
    private readonly IScheduleService _scheduleService;
    private readonly IScheduleRepository _scheduleRepository;
    // private readonly IScheduleStatusRepository _scheduleStatusRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateScheduleUseCaseImpl(IScheduleService scheduleService, IScheduleRepository scheduleRepository, IHttpContextAccessor httpContextAccessor)
    {
        _scheduleService = scheduleService;
        _scheduleRepository = scheduleRepository;
        _httpContextAccessor = httpContextAccessor;
        // _scheduleStatusRepository = scheduleStatusRepository;
    }
    
    public async Task Execute(CreateScheduleDto createScheduleDto)
    {
        Schedule schedule = CreateSchedule(createScheduleDto);
        await InsertSchedule(schedule);
    }

    public Schedule CreateSchedule(CreateScheduleDto createScheduleDto)
    {
        string? userId = _httpContextAccessor.HttpContext?.Items["UserId"]?.ToString();
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("UserId is not provided");
        }

        // ScheduleStatus? scheduleStatus = await _scheduleStatusRepository.FindScheduleStatusById("1");
        //
        // if (scheduleStatus == null)
        // {
        //     throw new EntityNotFoundException("Schedule status not found");
        // }
        //
        Schedule schedule = _scheduleService.CreateSchedule(
            createScheduleDto.QuizId,
            userId,
            createScheduleDto.StartAt,
            createScheduleDto.EndAt,
            createScheduleDto.MaxParticipants);
        
        // schedule.Status = scheduleStatus;

        return schedule;
    }

    public async Task InsertSchedule(Schedule schedule)
    {
        await _scheduleRepository.InsertSchedule(schedule);
    }
}