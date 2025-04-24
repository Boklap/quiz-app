using QuizResultService.Application.Dtos;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Application.Ports.Inbound.Admin;

public interface IGetPaginatedQuizResultByStatusUseCase
{
    Task<List<QuizResultDto>> Execute(string statusId, int page, int pageSize);
    Task<List<QuizResult>?> GetQuizResultByStatus(string statusId, int page, int pageSize);
}