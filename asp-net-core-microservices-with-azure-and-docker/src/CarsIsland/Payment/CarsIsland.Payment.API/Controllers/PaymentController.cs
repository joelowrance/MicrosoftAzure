using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarsIsland.Payment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }
    }
}
