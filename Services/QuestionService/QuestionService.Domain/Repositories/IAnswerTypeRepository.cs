using QuestionService.Domain.Entities;

namespace QuestionService.Domain.Repositories;

public interface IAnswerTypeRepository
{
    Task<List<AnswerType>?> FetchAnswerType();
}