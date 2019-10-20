using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using Orders;

namespace Shipping.Service.Infrastructure
{
    public class EndpointManagement : IHostedService
    {
        private readonly Bus _bus;
        private IEndpointInstance _endpoint;

        public EndpointManagement(Bus bus) { _bus = bus; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _endpoint = await Endpoint.Start(_bus.Configuration).ConfigureAwait(false);
            _endpoint.Subscribe<OrderPlaced>().GetAwaiter().GetResult();
            _endpoint.Subscribe<OrderBilled>().GetAwaiter().GetResult();
            _bus.Session = _endpoint;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _endpoint.Stop().ConfigureAwait(false);

            _bus.Session = null;
        }
    }
}