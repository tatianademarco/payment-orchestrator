using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Entities;
using Payment.Application.Abstractions.Messaging;
using Payment.Application.Abstractions.Persistence;

namespace Payment.Application.Payments.Commands
{
    public class CreatePaymentHandler
    {
        private readonly IPaymentRepository _repository;
        private readonly IPaymentPublisher _publisher;

        public CreatePaymentHandler(IPaymentRepository repository, IPaymentPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }
        public async Task<Guid> Handle(CreatePaymentCommand command)
        {
            var payment = new Domain.Entities.Payment(
                command.Amount,
                command.Currency,
                command.CardNumber
            );

            await _repository.SaveAsync(payment);

            await _publisher.PublishAsync(payment);

            return payment.Id;
        }
    }
}
