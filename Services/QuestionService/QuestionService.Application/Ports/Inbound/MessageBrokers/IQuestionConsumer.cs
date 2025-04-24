using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound;

public interface IQuestionConsumer
{
    Task ConsumeMessage();
    Task<List<Question>?> GetQuestionById(List<string> questionIds);
}