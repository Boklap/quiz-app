using QuizService.Domain.Entities;
using QuizService.Domain.ValueObjects.FinalizedQuizDetail;

namespace QuizService.Domain.Repositories;

public interface IQuizRepository
{
    Task InsertQuiz(Quiz quiz);
    Task<Quiz?> FindQuizById(string quizId);
    Task<List<Quiz>> FindPaginatedQuizzez(int page, int pageSize);
    Task<List<Quiz>> FindQuizzezByStatus(string statusId, int page, int pageSize);
    Task<List<Quiz>> FindQuizzezByCreator(string userId, int page, int pageSize);
    Task<List<Quiz>> FindQuizzezByTag(string tagId, int page, int pageSize);
    Task<List<Quiz>?> FindQuizzesByDate(DateTime startAt, DateTime endAt);
    Task<List<Quiz>?> FindQuizzesByIds(List<string> quizIds);
    Task UpdateQuiz(Quiz quiz);
}