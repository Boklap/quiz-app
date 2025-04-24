using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;
using QuestionService.Infrastructure.Data;

namespace QuestionService.Infrastructure.Repositories;

public class QuestionRepositoryImpl : IQuestionRepository
{
    private readonly QuestionServiceDbContext _context;

    public QuestionRepositoryImpl(QuestionServiceDbContext context)
    {
        _context = context;
    }

    public async Task InsertQuestion(Question question)
    {
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();
    }
  
    public async Task<List<Question>> GetAllQuestions(int page, int pageSize)
    {
        return await _context.Questions
            .OrderByDescending(q => q.CreatedAt)
            .Where(q => !q.IsDeleted)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Question?> FindQuestionById(ObjectId questionId)
    {
        return await _context.Questions
            .Where(q => !q.IsDeleted)
            .FirstOrDefaultAsync(q => q.Id == questionId);
    }

    public async Task<List<Question>> FindQuestionByStatus(string status, int page, int pageSize)
    {
        return await _context.Questions
            .Where(q => q.Status.ToLower() == status && !q.IsDeleted)
            .Skip((page-1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Question>> FindQuestionByUserId(string userId, int page, int pageSize)
    {
        return await _context.Questions
            .Where(q => q.CreatedBy == userId && !q.IsDeleted)
            .Skip((page-1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Question>?> FindQuestionByQuestionIds(List<string> questionIds)
    {
        var objectIds = questionIds.Select(ObjectId.Parse).ToList();
        
        return await _context.Questions
            .Where(q => objectIds.Contains(q.Id) && !q.IsDeleted)
            .ToListAsync();
    }

    public async Task UpdateQuestion(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
    }
}