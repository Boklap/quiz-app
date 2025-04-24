using MongoDB.Bson;
using MongoDB.Driver.Linq;
using QuizResultService.Domain.Entities;
using QuizResultService.Domain.Repositories;
using QuizResultService.Infrastructure.Data;

namespace QuizResultService.Infrastructure.Repositories;

public class QuizResultRepositoryImpl : IQuizResultRepository
{
    private readonly QuizResultServiceDbContext _context;

    public QuizResultRepositoryImpl(QuizResultServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task InsertQuizResult(QuizResult quizResult)
    {
        await _context.QuizResults.AddAsync(quizResult);
        await _context.SaveChangesAsync();
    }

    public async Task<QuizResult?> FindQuizResultByQuizResultId(ObjectId quizResultId)
    {
        return await _context.QuizResults
            .Where(q => !q.IsDeleted)
            .FirstOrDefaultAsync(q => q.Id == quizResultId);
    }

    public async Task<List<QuizResult>?> FindQuizResultByParticipantId(string participantId, int page, int pageSize)
    {
        return await _context.QuizResults
            .AsQueryable()
            .Where(q => !q.IsDeleted && q.ParticipantId == participantId)
            .OrderBy(q => q.Schedule.StartAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<QuizResult>?> FindQuizResultByScheduleId(string scheduleId, int page, int pageSize)
    {
        return await _context.QuizResults
            .AsQueryable()
            .Where(q => !q.IsDeleted && q.Schedule.Id == scheduleId)
            .OrderBy(q => q.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<QuizResult>?> FindQuizResultByQuizId(string quizId, int page, int pageSize)
    {
        return await _context.QuizResults
            .AsQueryable()
            .Where(q => !q.IsDeleted && q.Quiz.Id == quizId)
            .OrderBy(q => q.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<QuizResult>?> FindQuizResultByStatus(string status, int page, int pageSize)
    {
        return await _context.QuizResults
            .AsQueryable()
            .Where(q => !q.IsDeleted && q.Status.ToString() == status)
            .OrderBy(q => q.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task UpdateQuizResult(QuizResult quizResult)
    {
        _context.QuizResults.Update(quizResult);
        await _context.SaveChangesAsync();
    }
}