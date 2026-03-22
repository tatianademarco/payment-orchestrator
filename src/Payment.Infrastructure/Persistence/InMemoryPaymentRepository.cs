using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Application.Abstractions.Persistence;
using Payment.Domain.Entities;

namespace Payment.Infrastructure.Persistence
{
    public class InMemoryPaymentRepository : IPaymentRepository
    {
        private static readonly List<Domain.Entities.Payment> _payments = new();

        public Task SaveAsync(Domain.Entities.Payment payment)
        {
            _payments.Add(payment);
            return Task.CompletedTask;
        }

        public Task<Domain.Entities.Payment?> GetByIdAsync(Guid id)
        {
            var payment = _payments.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(payment);
        }
    }
}
