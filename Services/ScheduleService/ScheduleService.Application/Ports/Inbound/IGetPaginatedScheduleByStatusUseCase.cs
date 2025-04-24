using ScheduleService.Application.Dtos;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Application.Ports.Inbound;

public interface IGetPaginatedScheduleByStatusUseCase
{
    public Task<List<ScheduleDto>> Execute(string statusId, int page, int pageSize);
    public Task<List<Schedule>> GetPaginatedScheduleByStatus(string statusId, int page, int pageSize);
}