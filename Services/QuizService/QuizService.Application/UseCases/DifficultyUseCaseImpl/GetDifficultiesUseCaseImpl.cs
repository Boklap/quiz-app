using QuizService.Application.Ports.Inbound.UseCases.DifficultyUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;

namespace QuizService.Application.UseCases.DifficultyUseCaseImpl;

public class GetDifficultiesUseCaseImpl : IGetDifficultiesUseCase
{
    private readonly IDifficultyRepository _repository;

    public GetDifficultiesUseCaseImpl(IDifficultyRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<Difficulty>> Execute()
    {
        List<Difficulty>? difficulties = await _repository.FindDifficulties();
        if(difficulties is null) return new();

        return difficulties;
    }
}