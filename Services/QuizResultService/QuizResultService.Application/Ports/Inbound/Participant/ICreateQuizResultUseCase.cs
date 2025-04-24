using QuizResultService.Application.Dtos;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Application.Ports.Inbound.Participant;

public interface ICreateQuizResultUseCase
{
    Task Execute(CreateQuizResultDto createQuizResultDto);
    QuizResult CreateQuizResult(CreateQuizResultDto createQuizResultDto);
    Task InsertQuizResult(QuizResult quizResult);
}