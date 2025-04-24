using QuestionService.Domain.Entities;

namespace QuestionService.Domain.Repositories;

public interface IQuestionStatusRepository
{
    Task<List<QuestionStatus>> FetchQuestionStatus();
}