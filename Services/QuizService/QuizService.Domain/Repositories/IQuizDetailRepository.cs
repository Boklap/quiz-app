using QuizService.Domain.Entities;

namespace QuizService.Domain.Repositories;

public interface IQuizDetailRepository
{
    Task InsertQuestion(string quizId, List<string> questions);
    Task<List<string>> GetQuestionIdsByQuizId(string quizId);
    Task<List<string>?> GetInvalidQuestionIds(string quizId, List<string> questionIds);
    Task UpdateQuestion(QuizDetail quizDetail);
}