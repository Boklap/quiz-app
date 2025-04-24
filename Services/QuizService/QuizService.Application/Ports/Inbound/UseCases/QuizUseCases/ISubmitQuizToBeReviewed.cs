using QuizService.Application.Dtos;
using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface ISubmitQuizToBeReviewed
{
    Task Execute(string quizId);
    Task<Quiz?> IsQuizExist(string quizId);
    Task SubmitQuiz(Quiz quiz);
}