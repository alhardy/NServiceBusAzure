using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Orders;

namespace Shipping.Service.Application.Policies
{
    public class ShippingPolicy : Saga<ShippingPolicyData>,
        IAmStartedByMessages<OrderBilled>,
        IAmStartedByMessages<OrderPlaced>
    {
        private static readonly ILog Log = LogManager.GetLogger<ShippingPolicy>();

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ShippingPolicyData> mapper)
        {
            mapper.ConfigureMapping<OrderPlaced>(message => message.OrderId)
                .ToSaga(sagaData => sagaData.OrderId);
            
            mapper.ConfigureMapping<OrderBilled>(message => message.OrderId)
                .ToSaga(sagaData => sagaData.OrderId);
        }

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            Log.Info($"OrderPlaced message received.");
            
            Data.IsOrderPlaced = true;
            
            return ProcessOrder(context);
        }

        public Task Handle(OrderBilled message, IMessageHandlerContext context)
        {
            Log.Info($"OrderBilled message received.");
            
            Data.IsOrderBilled = true;
            
            return ProcessOrder(context);
        }

        private async Task ProcessOrder(IMessageHandlerContext context)
        {
            if (Data.IsOrderPlaced && Data.IsOrderBilled)
            {
                await context.SendLocal(new ShipOrder { OrderId = Data.OrderId });
                
                MarkAsComplete();
            }
        }
    }
}