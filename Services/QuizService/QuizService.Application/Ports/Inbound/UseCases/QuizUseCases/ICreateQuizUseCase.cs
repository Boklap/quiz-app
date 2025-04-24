using QuizService.Application.Dtos;
using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;

public interface ICreateQuizUseCase
{
    Task<string> Execute(CreateQuizDto createQuizDto);
    Quiz CreateQuiz(CreateQuizDto createQuizDto);
    Task InsertQuiz(Quiz quiz);
}