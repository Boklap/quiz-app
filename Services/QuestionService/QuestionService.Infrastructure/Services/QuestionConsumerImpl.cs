using System.Text;
using Newtonsoft.Json;
using QuestionService.Application.Ports.Inbound;
using QuestionService.Application.Ports.Outbound;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;
using QuestionService.Shared.Exceptions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace QuestionService.Infrastructure.Services;

public class QuestionConsumerImpl : IQuestionConsumer
{
    private readonly IConnection _conn;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionPublisher _questionPublisher;
    private readonly string? _queueName;

    public QuestionConsumerImpl(IConnection conn, IQuestionRepository questionRepository, IQuestionPublisher questionPublisher)
    {
        _queueName = Environment.GetEnvironmentVariable("RABBITMQ_QUEUE");
        _conn = conn;
        _questionRepository = questionRepository;
        _questionPublisher = questionPublisher;
    }
    
    public async Task ConsumeMessage()
    {
        if (_queueName == null)
        {
            throw new EnvVariableEmptyException("RabbitMQ channel env is not configured");
        }
        
        IChannel channel = await _conn.CreateChannelAsync();
        QueueDeclareOk response = await channel.QueueDeclarePassiveAsync(_queueName);
        AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (ch, ea) =>
        {
            var body = ea.Body.ToArray();

            string message = Encoding.UTF8.GetString(body);
            List<string>? questionids = JsonConvert.DeserializeObject<List<string>>(message);

            if (questionids == null)
            {
                return;
            }
            
            List<Question>? questions = await GetQuestionById(questionids);

            if (questions == null)
            {
                return;
            }
            
            await _questionPublisher.PublishQuestion(questions);
            await channel.BasicAckAsync(ea.DeliveryTag, false);
        };

        string consumerTag = await channel.BasicConsumeAsync(_queueName, false, consumer);
    }

    public async Task<List<Question>?> GetQuestionById(List<string> questionIds)
    {
        return await _questionRepository.FindQuestionByQuestionIds(questionIds);
    }
}