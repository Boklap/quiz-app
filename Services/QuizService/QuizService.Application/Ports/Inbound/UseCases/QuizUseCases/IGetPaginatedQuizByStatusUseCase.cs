using QuizService.Application.Dtos;
using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IGetPaginatedQuizByStatusUseCase
{
    Task<List<QuizDto>> Execute(string status, int page, int pageSize);
    Task<List<Quiz>> GetPaginatedQuizByStatus(string status, int page, int pageSize);
}