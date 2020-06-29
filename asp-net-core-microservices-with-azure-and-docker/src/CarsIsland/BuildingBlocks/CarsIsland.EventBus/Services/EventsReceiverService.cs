using Azure.Messaging.ServiceBus;
using CarsIsland.EventBus.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CarsIsland.EventBus.Services
{
    public class EventsReceiverService : IEventReceiverService
    {
        private readonly ServiceBusReceiver _serviceBusReceiver;
        private readonly ILogger<EventsReceiverService> _logger;

        public EventsReceiverService(ServiceBusReceiver serviceBusReceiver,
                                       ILogger<EventsReceiverService> logger)
        {
            _serviceBusReceiver = serviceBusReceiver;
            _logger = logger;
        }

        public async Task ReceiveEventAsync(CancellationToken cancellationToken)
        {
            try
            {
                var message = await _serviceBusReceiver.ReceiveAsync();
            }

            catch (ServiceBusException ex)
            {
                _logger.LogError($"{nameof(ServiceBusException)} - error details: {ex.Message}");
                throw;
            }
        }
    }
}
