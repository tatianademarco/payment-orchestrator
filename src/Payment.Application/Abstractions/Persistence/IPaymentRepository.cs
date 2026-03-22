using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Entities;

namespace Payment.Application.Abstractions.Persistence
{
    public interface IPaymentRepository
    {
        Task SaveAsync(Domain.Entities.Payment payment);

        Task<Domain.Entities.Payment?> GetByIdAsync(Guid id);
    }
}
