using QuizService.Domain.Entities;

namespace QuizService.Application.Ports.Inbound.UseCases.TagUseCases;

public interface IGetTagUseCase
{
    Task<List<Tag>> Execute();
}