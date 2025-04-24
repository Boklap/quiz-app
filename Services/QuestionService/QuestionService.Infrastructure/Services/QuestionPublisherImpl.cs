using System.Text;
using Newtonsoft.Json;
using QuestionService.Application.Ports.Outbound;
using QuestionService.Domain.Entities;
using QuestionService.Shared.Exceptions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace QuestionService.Infrastructure.Services;

public class QuestionPublisherImpl : IQuestionPublisher
{
    private readonly IConnection _conn;
    private readonly string? _exchange;
    private readonly string? _queue;
    private readonly string? _routingKey;
    
    
    public QuestionPublisherImpl(IConnection conn)
    {
        _exchange = Environment.GetEnvironmentVariable("RABBITMQ_QUESTION_TO_QUIZ_EXCHANGE");
        _queue = Environment.GetEnvironmentVariable("RABBITMQ_QUIZ_QUEUE");
        _routingKey = Environment.GetEnvironmentVariable("RABBITMQ_QUESTION_TO_QUIZ_ROUTING");
        _conn = conn;
    }
    
    public async Task PublishQuestion(List<Question> questions)
    {
        if (_exchange == null || _queue == null || _routingKey == null)
        {
            throw new EnvVariableEmptyException("Rabbitmq env configured");
        }
        
        IChannel channel = await _conn.CreateChannelAsync();
        QueueDeclareOk response = await channel.QueueDeclarePassiveAsync(_queue);
        string json = JsonConvert.SerializeObject(questions);
        var body = Encoding.UTF8.GetBytes(json);
        var props = new BasicProperties();
        
        await channel.BasicPublishAsync(_exchange, _routingKey, mandatory: true, basicProperties: props, body: body);
    }
}