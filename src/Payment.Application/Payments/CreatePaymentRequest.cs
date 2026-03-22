using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Payments
{
    public class CreatePaymentRequest
    {
        public decimal Amount { get; set; }

        public required string Currency { get; set; }

        public required string CardNumber { get; set; }
    }
}
