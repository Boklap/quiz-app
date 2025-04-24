using ScheduleService.Application.Dtos;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Application.Ports.Inbound;

public interface ICreateScheduleUseCase
{
    Task Execute(CreateScheduleDto createScheduleDto);
    Schedule CreateSchedule(CreateScheduleDto createScheduleDto);
    Task InsertSchedule(Schedule schedule);
}