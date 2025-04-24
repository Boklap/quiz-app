using ScheduleService.Domain.Entities;

namespace ScheduleService.Domain.Services.Interfaces;

public interface IScheduleService
{
    Schedule CreateSchedule(
        string quizId,
        string createdBy,
        DateTime startAt,
        DateTime endAt,
        int maxParticipants
        );
    
    string GenerateId();
}