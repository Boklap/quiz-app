using QuizService.Domain.Entities;

namespace QuizService.Domain.Repositories;

public interface IDifficultyRepository
{
    Task<string?> FindDifficultyNameById(string difficultyId);
    Task<List<Difficulty>?> FindDifficulties();
}