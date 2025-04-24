using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Services.Interfaces;

namespace ScheduleService.Domain.Services.Impl;

public class ScheduleServiceImpl : IScheduleService
{
    public Schedule CreateSchedule(string quizId, string createdBy, DateTime startAt, DateTime endAt,
        int maxParticipants)
    {
        string id = GenerateId();

        return new Schedule(
            id,
            quizId,
            createdBy,
            startAt,
            endAt,
            maxParticipants
            );
    }

    public string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }
}