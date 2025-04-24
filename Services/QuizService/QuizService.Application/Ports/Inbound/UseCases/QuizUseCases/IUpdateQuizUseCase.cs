using QuizService.Application.Dtos;
using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface IUpdateQuizUseCase
{
    Task Execute(UpdateQuizDto quizDto);
    Task<Quiz?> IsQuizExist(string quizId);
    Task UpdateQuiz(Quiz quiz);
}