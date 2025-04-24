using QuizService.Application.Dtos;
using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IGetPaginatedFinalizedQuiz
{
    Task<List<QuizDto>> Execute(int page, int pageSize);
    Task<List<Quiz>> GetPaginatedQuizByStatus(int page, int pageSize);
}