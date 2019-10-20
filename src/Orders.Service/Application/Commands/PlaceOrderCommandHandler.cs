using System;
using System.Threading.Tasks;
using NServiceBus;

namespace Orders.Service.Application.Commands
{
    public class PlaceOrderCommandHandler : IHandleMessages<PlaceOrder>
    {
        public Task Handle(PlaceOrder command, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received Order with id {command.OrderId}");

            return context.Publish<OrderPlaced>(@event => { @event.OrderId = command.OrderId; });
        }
    }
}