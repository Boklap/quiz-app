using QuizService.Domain.Entities;

namespace QuizService.Domain.Repositories;

public interface ITagRepository
{
    Task<string?> FindTagNameById(string tagId);
    Task<List<Tag>?> FindTag();

}