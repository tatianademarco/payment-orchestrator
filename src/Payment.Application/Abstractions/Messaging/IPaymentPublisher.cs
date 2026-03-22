using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Entities;

namespace Payment.Application.Abstractions.Messaging
{
    public interface IPaymentPublisher
    {
        Task PublishAsync(Domain.Entities.Payment payment);
    }
}
