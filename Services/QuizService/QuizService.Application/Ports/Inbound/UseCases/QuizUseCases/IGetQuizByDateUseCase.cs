using QuizService.Application.Dtos;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IGetQuizByDateUseCase
{
    Task<List<QuizDto>> Execute(DateTime startAt, DateTime endAt);
}