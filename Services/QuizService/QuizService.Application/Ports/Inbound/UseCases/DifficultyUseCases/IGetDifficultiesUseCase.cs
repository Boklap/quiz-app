using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.DifficultyUseCases;

public interface IGetDifficultiesUseCase
{
    Task<List<Difficulty>> Execute();
}