using Microsoft.EntityFrameworkCore;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Infrastructure.Data.PostgresDbContext;

namespace QuizService.Infrastructure.Repositories;

public class QuizDetailRepositoryImpl : IQuizDetailRepository
{
    private PostgresQuizServiceDbContext _context;

    public QuizDetailRepositoryImpl(PostgresQuizServiceDbContext context)
    {
        _context = context;
    }

    public async Task InsertQuestion(string quizId, List<string> questions)
    {
        foreach (var questionId in questions)
        {
            var exists = await _context.QuizDetails
                .AnyAsync(qd => qd.QuizId == quizId && qd.QuestionId == questionId);
            if (!exists)
            {
                _context.QuizDetails.Add(new QuizDetail
                {
                    QuizId = quizId,
                    QuestionId = questionId,
                });
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<string>> GetQuestionIdsByQuizId(string quizId)
    {
        return await _context.QuizDetails
            .Where(qd => qd.QuizId == quizId)
            .Select(qd => qd.QuestionId)
            .ToListAsync();
    }

    public async Task<List<string>?> GetInvalidQuestionIds(string quizId, List<string> questionIds)
    {
        List<string>? existingIds = await _context.QuizDetails
            .Where(qd => questionIds.Contains(qd.QuestionId))
            .Select(qd => qd.QuestionId)
            .ToListAsync();

        List<string>? invalidIds = questionIds.Intersect(existingIds).ToList();
        
        return invalidIds;
    }

    public async Task UpdateQuestion(QuizDetail quizDetail)
    {
        throw new NotImplementedException();
    }
}