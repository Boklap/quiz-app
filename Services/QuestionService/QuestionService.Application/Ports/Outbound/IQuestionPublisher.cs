using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Outbound;

public interface IQuestionPublisher
{
    Task PublishQuestion(List<Question> questions);
}