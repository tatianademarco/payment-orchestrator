using Microsoft.AspNetCore.Mvc;
using Payment.Application.Payments;
using Payment.Application.Payments.Commands;

namespace Payment.Api.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly CreatePaymentHandler _handler;

        public PaymentsController(CreatePaymentHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentRequest request)
        {
            var command = new CreatePaymentCommand
            {
                Amount = request.Amount,
                Currency = request.Currency,
                CardNumber = request.CardNumber
            };

            var paymentId = await _handler.Handle(command);

            return Accepted(new { paymentId });
        }
    }
}
