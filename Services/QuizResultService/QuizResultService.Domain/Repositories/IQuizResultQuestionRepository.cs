using QuizResultService.Domain.ValueObjects.QuizResult;
using QuizResultService.Domain.ValueObjects.QuizResultAnswer;

namespace QuizResultService.Domain.Repositories;

public interface IQuizResultQuestionRepository
{
    Task<List<Question>?> GetParticipantQuizByQuizId(string participantId, string quizId, int page, int pageSize);
}