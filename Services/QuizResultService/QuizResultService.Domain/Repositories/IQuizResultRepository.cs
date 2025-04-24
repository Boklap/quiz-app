using MongoDB.Bson;
using QuizResultService.Domain.Entities;
using QuizResultService.Domain.ValueObjects.QuizResult;

namespace QuizResultService.Domain.Repositories;

public interface IQuizResultRepository
{
    Task InsertQuizResult(QuizResult quizResult);
    Task<QuizResult?> FindQuizResultByQuizResultId(ObjectId quizResultId);
    Task<List<QuizResult>?> FindQuizResultByParticipantId(string participantId, int page, int pageSize);
    Task<List<QuizResult>?> FindQuizResultByScheduleId(string scheduleId, int page, int pageSize);
    Task<List<QuizResult>?> FindQuizResultByQuizId(string quizId, int page, int pageSize);
    Task<List<QuizResult>?> FindQuizResultByStatus(string status, int page, int pageSize);
    Task UpdateQuizResult(QuizResult quizResult);
}