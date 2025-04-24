using QuizService.Application.Dtos;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IGetQuizByQuizIds
{
    Task<List<QuizDto>> Execute(List<string> quizIds);
}