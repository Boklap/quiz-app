using ScheduleService.Application.Dtos;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Application.Ports.Inbound;

public interface IGetPaginatedScheduleUseCase
{
    public Task<List<ScheduleDto>> Execute(int page, int pageSize);
    public Task<List<Schedule>> GetPaginatedSchedule(int page, int pageSize);
}