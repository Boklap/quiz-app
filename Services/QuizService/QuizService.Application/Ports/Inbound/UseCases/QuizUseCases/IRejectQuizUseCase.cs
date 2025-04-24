using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IRejectQuizUseCase
{
    Task Execute(string quizId);
    Task<Quiz?> IsQuizExist(string quizId);
    Task RejectQuiz(Quiz quiz);
}