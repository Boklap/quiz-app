using QuizResultService.Application.Dtos;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Application.Ports.Inbound.Admin;

public interface IGradeQuizResultUseCase
{
    Task Execute(UpdateQuizResultDto updateQuizResultDto);
    Task<QuizResult?> IsQuizExist(string quizId);
    Task UpdateQuizResult(QuizResult quizResult);
}