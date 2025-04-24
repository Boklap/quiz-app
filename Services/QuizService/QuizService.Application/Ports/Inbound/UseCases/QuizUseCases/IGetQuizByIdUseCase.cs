using QuizService.Application.Dtos;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IGetQuizByIdUseCase
{
    Task<QuizDto> Execute(string quizId);
}