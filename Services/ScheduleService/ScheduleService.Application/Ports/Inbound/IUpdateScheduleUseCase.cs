using ScheduleService.Application.Dtos;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Application.Ports.Inbound;

public interface IUpdateScheduleUseCase
{
    public Task Execute(UpdateScheduleDto updateScheduleDto);
    public Task<Schedule?> IsScheduleExist(string scheduleId);
    public Task UpdateSchedule(Schedule schedule);
}