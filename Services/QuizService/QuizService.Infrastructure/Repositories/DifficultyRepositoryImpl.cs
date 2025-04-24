using Microsoft.EntityFrameworkCore;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Infrastructure.Data.PostgresDbContext;

namespace QuizService.Infrastructure.Repositories;

public class DifficultyRepositoryImpl : IDifficultyRepository
{
    private PostgresQuizServiceDbContext _context;

    public DifficultyRepositoryImpl(PostgresQuizServiceDbContext context)
    {
        _context = context;
    }

    public Task<string?> FindDifficultyNameById(string difficultyId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Difficulty>?> FindDifficulties()
    {
        return await _context.Difficulties.ToListAsync();
    }
}