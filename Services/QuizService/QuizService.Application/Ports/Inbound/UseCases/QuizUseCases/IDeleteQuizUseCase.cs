using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IDeleteQuizUseCase
{
    Task Execute(string quizId);
    Task<Quiz?> IsQuizExist(string quizId);
    Task DeleteQuiz(Quiz quiz);
}