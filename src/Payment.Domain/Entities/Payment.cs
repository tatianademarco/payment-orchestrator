using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; private set; }

        public decimal Amount { get; private set; }

        public string Currency { get; private set; }

        public string CardNumber { get; private set; }

        public PaymentStatus Status { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Payment(decimal amount, string currency, string cardNumber)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Currency = currency;
            CardNumber = cardNumber;
            Status = PaymentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsProcessed()
        {
            Status = PaymentStatus.Processed;
        }

        public void MarkAsFailed()
        {
            Status = PaymentStatus.Failed;
        }
    }
}
