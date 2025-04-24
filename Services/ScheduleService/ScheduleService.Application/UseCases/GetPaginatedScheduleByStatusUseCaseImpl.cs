using ScheduleService.Application.Dtos;
using ScheduleService.Application.Mappers;
using ScheduleService.Application.Ports.Inbound;
using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;

namespace ScheduleService.Application.UseCases;

public class GetPaginatedScheduleByStatusUseCaseImpl : IGetPaginatedScheduleByStatusUseCase
{
    private readonly IScheduleRepository _scheduleRepository;

    public GetPaginatedScheduleByStatusUseCaseImpl(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
    
    public async Task<List<ScheduleDto>> Execute(string statusId, int page, int pageSize)
    {
        List<Schedule> schedules = await GetPaginatedScheduleByStatus(statusId, page, pageSize);
        if (!schedules.Any()) return new List<ScheduleDto>();

        return schedules.Select(ScheduleMapper.ToDto).ToList();
    }

    public async Task<List<Schedule>> GetPaginatedScheduleByStatus(string statusId, int page, int pageSize)
    {
        return await _scheduleRepository.GetPaginatedScheduleByStatus(statusId, page, pageSize);

    }
}