using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IGetQuestionStatusUseCase
{
    Task<List<string>> Execute();
    Task<List<QuestionStatus>?> FetchQuestionStatus();
}