using NServiceBus;

// ReSharper disable CheckNamespace
namespace Orders
    // ReSharper restore CheckNamespace
{
    // ReSharper disable InconsistentNaming
    public interface OrderPlaced : IEvent
        // ReSharper restore InconsistentNaming
    {
        string OrderId { get; set; }
    }
}