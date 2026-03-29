using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Payment.Application.Abstractions.Messaging;
using Payment.Domain.Entities;
using RabbitMQ.Client;

namespace Payment.Infrastructure.Messaging
{
    public class RabbitMqPaymentPublisher : IPaymentPublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqPaymentPublisher()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: "payments",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        public Task PublishAsync(Domain.Entities.Payment payment)
        {
            var message = JsonSerializer.Serialize(payment);

            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: "",
                routingKey: "payments",
                basicProperties: null,
                body: body
            );

            return Task.CompletedTask;
        }
    }
}
