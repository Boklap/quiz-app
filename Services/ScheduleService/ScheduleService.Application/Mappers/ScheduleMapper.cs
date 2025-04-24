using ScheduleService.Application.Dtos;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Application.Mappers;

public static class ScheduleMapper
{
    public static ScheduleDto ToDto(Schedule schedule)
    {
        return new ScheduleDto
        {
            StatudId = schedule.StatusId,
            StartAt = schedule.StartAt,
            EndAt = schedule.EndAt,
            MaxParticipants = schedule.MaxParticipant.Value
        };
    }
}