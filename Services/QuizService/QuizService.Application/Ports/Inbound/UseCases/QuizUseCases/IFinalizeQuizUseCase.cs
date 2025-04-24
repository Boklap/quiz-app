using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IFinalizeQuizUseCase
{
    Task Execute(string quizId);
    Task<Quiz?> IsQuizExist(string quizId);
    Task FinalizeQuiz(Quiz quiz);
}