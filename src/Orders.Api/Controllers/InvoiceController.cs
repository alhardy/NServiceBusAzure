using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Orders.Api.Application.Requests;

namespace Orders.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMessageSession _messageSession;

        public InvoiceController(IMessageSession messageSession)
        {
            _messageSession = messageSession;
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(SubmitInvoiceRequest request)
        {
            await _messageSession.Send(request.ToCommand());

            return Accepted();
        }
    }
}