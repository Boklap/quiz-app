using Microsoft.AspNetCore.Mvc;
using QuizService.Application.Ports.Inbound.UseCases.TagUseCases;
using QuizService.Domain.Entities;

namespace QuizService.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class TagController : ControllerBase
{
    private readonly IGetTagUseCase _getTagUseCase;

    public TagController(IGetTagUseCase getTagUseCase)
    {
        _getTagUseCase = getTagUseCase;
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetTags()
    {
        List<Tag> tags = await _getTagUseCase.Execute();
        return Ok(tags);
    }
}