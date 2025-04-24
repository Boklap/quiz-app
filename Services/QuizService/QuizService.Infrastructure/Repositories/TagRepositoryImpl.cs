using Microsoft.EntityFrameworkCore;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Infrastructure.Data.PostgresDbContext;

namespace QuizService.Infrastructure.Repositories;

public class TagRepositoryImpl : ITagRepository
{
    private readonly PostgresQuizServiceDbContext _context;

    public TagRepositoryImpl(PostgresQuizServiceDbContext context)
    {
        _context = context;
    }


    public Task<string?> FindTagNameById(string tagId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Tag>?> FindTag()
    {
        return await _context.Tags.ToListAsync();
    }
}