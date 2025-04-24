using Microsoft.EntityFrameworkCore;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;
using QuestionService.Infrastructure.Data;

namespace QuestionService.Infrastructure.Repositories;

public class QuestionStatusRepositoryImpl : IQuestionStatusRepository
{
    private readonly QuestionServiceDbContext _context;

    public QuestionStatusRepositoryImpl(QuestionServiceDbContext context)
    {
        _context = context;
    }
    
    public Task<List<QuestionStatus>> FetchQuestionStatus()
    {
        return _context.QuestionStatuses.ToListAsync();
    }
}