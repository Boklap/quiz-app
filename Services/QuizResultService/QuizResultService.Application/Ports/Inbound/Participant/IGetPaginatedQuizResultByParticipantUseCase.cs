using QuizResultService.Application.Dtos;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Application.Ports.Inbound.Participant;

public interface IGetPaginatedQuizResultByParticipantUseCase
{
    Task<List<QuizResultDto>> Execute(int page, int pageSize);
    Task<List<QuizResult>?> GetQuizResultByParticipant(string participantId, int page, int pageSize);
}