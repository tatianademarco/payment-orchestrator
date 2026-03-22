using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Application.Abstractions.Messaging;
using Payment.Domain.Entities;

namespace Payment.Infrastructure.Messaging
{
    public class FakePaymentPublisher : IPaymentPublisher
    {
        public Task PublishAsync(Domain.Entities.Payment payment)
        {
            Console.WriteLine($"[EVENT] Payment published: {payment.Id}");

            return Task.CompletedTask;
        }
    }
}
