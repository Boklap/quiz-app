using QuizResultService.Application.Dtos;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Application.Ports.Inbound.Admin;

public interface IGetPaginatedQuizResultByQuizUseCase
{
    Task<List<QuizResultDto>> Execute(string quizId, int page, int pageSize);
    Task<List<QuizResult>?> GetQuizResultByQuiz(string quizId, int page, int pageSize);
}