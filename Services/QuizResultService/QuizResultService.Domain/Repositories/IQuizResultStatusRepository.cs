using QuizResultService.Domain.Entities;

namespace QuizResultService.Domain.Repositories;

public interface IQuizResultStatusRepository
{
    Task<QuizResultStatus> GetQuizResultStatus(string status);
}