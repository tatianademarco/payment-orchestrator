using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Entities;

namespace Payment.Application.Payments.Commands
{
    public class CreatePaymentHandler
    {
        public async Task<Guid> Handle(CreatePaymentCommand command)
        {
            var payment = new Payment(
                command.Amount,
                command.Currency,
                command.CardNumber
            );

            // futuramente:
            // salvar no banco
            // publicar na fila

            await Task.CompletedTask;

            return payment.Id;
        }
    }
}
