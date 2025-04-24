using ScheduleService.Application.Dtos;
using ScheduleService.Application.Mappers;
using ScheduleService.Application.Ports.Inbound;
using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;

namespace ScheduleService.Application.UseCases;

public class GetPaginatedScheduleUseCaseImpl : IGetPaginatedScheduleUseCase
{
    private readonly IScheduleRepository _scheduleRepository;

    public GetPaginatedScheduleUseCaseImpl(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
    
    public async Task<List<ScheduleDto>> Execute(int page, int pageSize)
    {
        List<Schedule> schedules = await GetPaginatedSchedule(page, pageSize);
        if (!schedules.Any()) return new List<ScheduleDto>();

        return schedules.Select(ScheduleMapper.ToDto).ToList();
    }

    public async Task<List<Schedule>> GetPaginatedSchedule(int page, int pageSize)
    {
        return await _scheduleRepository.GetPaginatedSchedule(page, pageSize);
    }
}