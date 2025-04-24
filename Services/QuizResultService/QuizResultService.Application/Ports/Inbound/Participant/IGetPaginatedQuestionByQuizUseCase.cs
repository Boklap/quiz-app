using QuizResultService.Domain.ValueObjects.QuizResultAnswer;

namespace QuizResultService.Application.Ports.Inbound.Participant;

public interface IGetPaginatedQuestionByQuizUseCase
{
    Task<List<Question>> Execute(string quizId, int page, int pageSize);
    Task<List<Question>?> GetPaginatedQuestionByQuiz(string participantId, string quizId, int page, int pageSize);
}