using NServiceBus;

namespace Orders.Api.Infrastructure
{
    public class Bus
    {
        public Bus(EndpointConfiguration configuration) { Configuration = configuration; }

        public EndpointConfiguration Configuration { get; }

        public IMessageSession Session { get; set; }
    }
}