// using Microsoft.Extensions.DependencyInjection;
// using QuizService.Shared.Exceptions;
// using RabbitMQ.Client;
//
// namespace QuizService.Config.MessageBrokerConnection;
//
// public static class RabbitMqConnection
// {
//     public static async Task<IServiceCollection> AddRabbitMqConnection(this IServiceCollection services)
//     {
//         string? uri = Environment.GetEnvironmentVariable("RABBITMQ_URI");
//         
//         if (uri is null)
//         {
//             throw new EnvVariableEmptyException("Rabbitmq env is not configured");
//         }
//         
//         ConnectionFactory factory = new ConnectionFactory
//         {
//             Uri = new Uri(uri)
//         };
//         IConnection conn = await factory.CreateConnectionAsync();
//
//         services.AddSingleton(conn);
//         
//         return services;
//     }
// }