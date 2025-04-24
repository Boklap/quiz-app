using QuizService.Application.Dtos;
using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IGetPaginatedQuizByTagUseCase
{
    Task<List<QuizDto>> Execute(string tag, int page, int pageSize);
    Task<List<Quiz>> GetPaginatedQuizByTag(string tag, int page, int pageSize);
}