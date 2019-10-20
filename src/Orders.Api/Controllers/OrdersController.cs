using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Orders.Api.Application.Requests;

namespace Orders.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMessageSession _messageSession;

        public OrdersController(IMessageSession messageSession)
        {
            _messageSession = messageSession;
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(PlaceOrderRequest request)
        {
            await _messageSession.Send(request.ToCommand());

            return Accepted();
        }
    }
}