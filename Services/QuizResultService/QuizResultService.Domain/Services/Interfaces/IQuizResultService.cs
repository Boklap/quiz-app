using QuizResultService.Domain.Entities;
using QuizResultService.Domain.ValueObjects.QuizResult;

namespace QuizResultService.Domain.Services.Interfaces;

public interface IQuizResultService
{
    QuizResult CreateQuizResult(
        string participantId,
        Schedule schedule,
        Quiz quiz,
        Score score
        );
}