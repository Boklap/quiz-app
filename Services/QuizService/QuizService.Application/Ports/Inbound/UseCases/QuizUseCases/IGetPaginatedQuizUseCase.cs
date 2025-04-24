using QuizService.Application.Dtos;
using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IGetPaginatedQuizUseCase
{
    Task<List<QuizDto>> Execute(int page, int pageSize);
    Task<List<Quiz>> GetPaginatedQuiz(int page, int pageSize);
}