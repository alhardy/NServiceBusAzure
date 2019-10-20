using NServiceBus;

namespace Shipping.Service.Application.Policies
{
    public class ShippingPolicyData : ContainSagaData
    {
        public string OrderId { get; set; }
        
        public bool IsOrderPlaced { get; set; }
        
        public bool IsOrderBilled { get; set; }
    }
}