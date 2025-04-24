using MongoDB.Driver.Linq;
using QuizResultService.Domain.Repositories;
using QuizResultService.Domain.ValueObjects.QuizResult;
using QuizResultService.Domain.ValueObjects.QuizResultAnswer;
using QuizResultService.Infrastructure.Data;

namespace QuizResultService.Infrastructure.Repositories;

public class QuizResultQuestionRepositoryImpl : IQuizResultQuestionRepository
{
    private readonly QuizResultServiceDbContext _context;

    public QuizResultQuestionRepositoryImpl(QuizResultServiceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Question>?> GetParticipantQuizByQuizId(string participantId, string quizId, int page, int pageSize)
    {
        return await _context.QuizResultQuestions
            .AsQueryable()
            .Where(qrq => qrq.ParticipantId == participantId && qrq.QuizId == quizId)
            .SelectMany(qrq => qrq.Questions)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}