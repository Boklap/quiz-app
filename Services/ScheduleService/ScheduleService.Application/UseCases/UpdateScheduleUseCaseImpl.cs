using ScheduleService.Application.Dtos;
using ScheduleService.Application.Ports.Inbound;
using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;
using ScheduleService.Shared.Exceptions;

namespace ScheduleService.Application.UseCases;

public class UpdateScheduleUseCaseImpl : IUpdateScheduleUseCase
{
    private readonly IScheduleRepository _scheduleRepository;

    public UpdateScheduleUseCaseImpl(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
    
    public async Task Execute(UpdateScheduleDto updateScheduleDto)
    {
        Schedule? schedule = await IsScheduleExist(updateScheduleDto.Id);
        if (schedule == null)
        {
            throw new EntityNotFoundException("Schedule not found");
        }
        
        schedule.UpdateSchedule(
            updateScheduleDto.QuizId,
            updateScheduleDto.StartAt,
            updateScheduleDto.EndAt,
            updateScheduleDto.MaxParticipants
            );

        await UpdateSchedule(schedule);
    }

    public async Task<Schedule?> IsScheduleExist(string scheduleId)
    {
        return await _scheduleRepository.FindScheduleById(scheduleId);
    }

    public async Task UpdateSchedule(Schedule schedule)
    {
        await _scheduleRepository.UpdateSchedule(schedule);
    }
}