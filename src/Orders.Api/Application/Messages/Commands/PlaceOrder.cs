using NServiceBus;

// ReSharper disable CheckNamespace
namespace Orders
    // ReSharper restore CheckNamespace
{
    public class PlaceOrder : ICommand
    {
        public PlaceOrder(string orderId, long amount)
        {
            OrderId = orderId;
            Amount = amount;
        }
        
        public string OrderId { get; }
        public long Amount { get; }
    }
}