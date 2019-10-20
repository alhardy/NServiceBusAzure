using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace Shipping.Service.Application.Commands
{
    public class ShipOrderHandler : IHandleMessages<ShipOrder>
    {
        private static readonly ILog Log = LogManager.GetLogger<ShipOrderHandler>();

        public Task Handle(ShipOrder message, IMessageHandlerContext context)
        {
            Log.Info($"Order [{message.OrderId}] - Successfully shipped.");
            
            return Task.CompletedTask;
        }
    }
}