using System;
using System.Threading.Tasks;
using NServiceBus;
using Orders;

namespace Billing.Service.Application.Events
{
    public class PlaceOrderEventHandler : IHandleMessages<OrderPlaced>
    {
        public Task Handle(OrderPlaced @event, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received Order Placement with OrderId: {@event.OrderId}");

            return context.Publish<OrderBilled>(billed => { billed.OrderId = @event.OrderId; });
        }
    }
}