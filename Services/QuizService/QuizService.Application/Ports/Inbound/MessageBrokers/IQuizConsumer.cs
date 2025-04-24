using QuizService.Domain.ValueObjects.FinalizedQuizDetail;

namespace QuizService.Application.Ports.Inbound.MessageBrokers;

public interface IQuizConsumer
{
    Task ConsumeMessage();
}