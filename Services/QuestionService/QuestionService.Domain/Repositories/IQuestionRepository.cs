using MongoDB.Bson;
using QuestionService.Domain.Entities;

namespace QuestionService.Domain.Repositories;

public interface IQuestionRepository
{
    Task InsertQuestion(Question question);
    Task<List<Question>> GetAllQuestions(int page, int pageSize);
    Task<Question?> FindQuestionById(ObjectId questionId);
    Task<List<Question>> FindQuestionByStatus(string status, int page, int pageSize);
    Task<List<Question>> FindQuestionByUserId(string userId, int page, int pageSize);
    Task<List<Question>?> FindQuestionByQuestionIds(List<string> questionIds);
    Task UpdateQuestion(Question question);
    
}