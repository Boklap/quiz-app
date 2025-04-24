using ScheduleService.Application.Dtos;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Application.Ports.Inbound;

public interface IGetPaginatedScheduleByDateUseCase
{
    public Task<List<ScheduleDto>> Execute(DateTime startDate, DateTime endDate, int page, int pageSize);
    public Task<List<Schedule>> GetPaginatedScheduleByDate(DateTime startDate, DateTime endDate, int page, int pageSize);
}