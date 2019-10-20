namespace Orders.Api.Application.Requests
{
    public class PlaceOrderRequest
    {
        public string OrderId { get; set; }
        
        public long Amount { get; set; }

        public PlaceOrder ToCommand()
        {
            return new PlaceOrder(OrderId, Amount);
        }
    }
}