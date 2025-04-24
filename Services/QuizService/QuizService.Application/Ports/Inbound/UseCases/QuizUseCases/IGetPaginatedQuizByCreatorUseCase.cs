using QuizService.Application.Dtos;
using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IGetPaginatedQuizByCreatorUseCase
{
    Task<List<QuizDto>> Execute(string userId, int page, int pageSize);
    Task<List<Quiz>> GetPaginatedQuizByCreator(string userId, int page, int pageSize);
}