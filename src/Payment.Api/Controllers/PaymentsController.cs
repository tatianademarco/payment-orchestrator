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
        public async Task<IActionResult> CreatePayment(
        CreatePaymentCommand command)
        {
            var paymentId = await _handler.Handle(command);

            return Accepted(new { paymentId });
        }
    }
}
