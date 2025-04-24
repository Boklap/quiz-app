using ScheduleService.Application.Dtos;
using ScheduleService.Application.Mappers;
using ScheduleService.Application.Ports.Inbound;
using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;

namespace ScheduleService.Application.UseCases;

public class GetPaginatedScheduleByDateUseCaseImpl : IGetPaginatedScheduleByDateUseCase
{
    private readonly IScheduleRepository _scheduleRepository;

    public GetPaginatedScheduleByDateUseCaseImpl(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<List<ScheduleDto>> Execute(DateTime startDate, DateTime endDate, int page, int pageSize)
    {
        List<Schedule> schedules = await GetPaginatedScheduleByDate(startDate, endDate, page, pageSize);
        if (!schedules.Any()) return new List<ScheduleDto>();

        return schedules.Select(ScheduleMapper.ToDto).ToList();
    }

    public async Task<List<Schedule>> GetPaginatedScheduleByDate(DateTime startDate, DateTime endDate, int page, int pageSize)
    {
        return await _scheduleRepository.GetPaginatedScheduleByDate(startDate, endDate, page, pageSize);
    }
}