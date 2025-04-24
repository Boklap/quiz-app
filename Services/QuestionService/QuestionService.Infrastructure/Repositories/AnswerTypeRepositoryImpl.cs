using Microsoft.EntityFrameworkCore;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;
using QuestionService.Infrastructure.Data;

namespace QuestionService.Infrastructure.Repositories;

public class AnswerTypeRepositoryImpl : IAnswerTypeRepository
{

    private readonly QuestionServiceDbContext _context;

    public AnswerTypeRepositoryImpl(QuestionServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<AnswerType>?> FetchAnswerType()
    {
        return await _context.AnswerType.ToListAsync();
    }
}