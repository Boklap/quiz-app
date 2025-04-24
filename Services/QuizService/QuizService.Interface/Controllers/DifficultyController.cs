using Microsoft.AspNetCore.Mvc;
using QuizService.Application.Ports.Inbound.UseCases.DifficultyUseCases;
using QuizService.Domain.Entities;

namespace QuizService.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class DifficultyController : ControllerBase
{
    private readonly IGetDifficultiesUseCase _getDifficultiesUseCase;

    public DifficultyController(IGetDifficultiesUseCase getDifficultiesUseCase)
    {
        _getDifficultiesUseCase = getDifficultiesUseCase;
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetDifficulties()
    {
        List<Difficulty> difficulties = await _getDifficultiesUseCase.Execute();
        return Ok(difficulties);
    }
    
}
