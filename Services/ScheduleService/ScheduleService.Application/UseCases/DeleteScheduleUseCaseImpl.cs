using ScheduleService.Application.Ports.Inbound;
using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;
using ScheduleService.Shared.Exceptions;

namespace ScheduleService.Application.UseCases;

public class DeleteScheduleUseCaseImpl : IDeleteScheduleUseCase
{
    private readonly IScheduleRepository _scheduleRepository;

    public DeleteScheduleUseCaseImpl(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
    
    public async Task Execute(string scheduleId)
    {
        Schedule? schedule = await IsScheduleExist(scheduleId);
        if (schedule == null)
        {
            throw new EntityNotFoundException("Schedule not found");
        }
        
        await DeleteSchedule(schedule);
    }

    public async Task<Schedule?> IsScheduleExist(string scheduleId)
    {
        return await _scheduleRepository.FindScheduleById(scheduleId);
    }

    public async Task DeleteSchedule(Schedule schedule)
    {
        schedule.IsDeleted = true;
        await _scheduleRepository.UpdateSchedule(schedule);
    }
}