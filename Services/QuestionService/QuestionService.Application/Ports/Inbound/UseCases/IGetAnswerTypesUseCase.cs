using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IGetAnswerTypesUseCase
{
    Task<List<string>> Execute();
    Task<List<AnswerType>?> FetchAnswerTypes();
}