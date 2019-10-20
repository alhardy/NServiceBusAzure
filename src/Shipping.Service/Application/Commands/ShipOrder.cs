using NServiceBus;

// ReSharper disable CheckNamespace
namespace Shipping
    // ReSharper restore CheckNamespace
{
    public class ShipOrder : ICommand
    {
        public string OrderId { get; set; }
    }
}