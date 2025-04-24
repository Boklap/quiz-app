using Microsoft.EntityFrameworkCore;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Infrastructure.Data.PostgresDbContext;

namespace QuizService.Infrastructure.Repositories;

public class QuizRepositoryImpl : IQuizRepository
{
    private readonly PostgresQuizServiceDbContext _context;

    public QuizRepositoryImpl(PostgresQuizServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task InsertQuiz(Quiz quiz)
    {
        await _context.Quizzes.AddAsync(quiz);
        await _context.SaveChangesAsync();
    }

    public async Task<Quiz?> FindQuizById(string quizId)
    {
        return await _context.Quizzes
            .FirstOrDefaultAsync(q => q.Id == quizId);
    }

    public async Task<List<Quiz>> FindPaginatedQuizzez(int page, int pageSize)
    {
        return await _context.Quizzes
            .Where(q => !q.IsDeleted)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Quiz>> FindQuizzezByStatus(string statusId, int page, int pageSize)
    {
        return await _context.Quizzes
            .Where(q => q.QuizStatusId == statusId && !q.IsDeleted)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Quiz>> FindQuizzezByCreator(string userId, int page, int pageSize)
    {
        return await _context.Quizzes
            .Where(q => q.CreatedBy == userId && !q.IsDeleted)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Quiz>> FindQuizzezByTag(string tagId, int page, int pageSize)
    {
        return await _context.Quizzes
            .Where(q => q.TagId == tagId && !q.IsDeleted)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Quiz>?> FindQuizzesByDate(DateTime startAt, DateTime endAt)
    {
        return await _context.Quizzes
            .Where(q => q.CreatedAt >= startAt && q.CreatedAt <= endAt && !q.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<Quiz>?> FindQuizzesByIds(List<string> quizIds)
    {
        Console.WriteLine("dafjhgfhkjdsgfhjasdhfjhgd");
        Console.WriteLine(quizIds);
        return await _context.Quizzes
            .Where(q => !q.IsDeleted && quizIds.Contains(q.Id))
            .ToListAsync();
    }

    public async Task UpdateQuiz(Quiz quiz)
    {
        _context.Quizzes.Update(quiz);
        await _context.SaveChangesAsync();
    }
}