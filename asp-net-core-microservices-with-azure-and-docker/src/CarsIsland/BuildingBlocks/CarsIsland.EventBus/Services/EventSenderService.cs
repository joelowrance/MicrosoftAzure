using Azure.Messaging.ServiceBus;
using CarsIsland.EventBus.Events;
using CarsIsland.EventBus.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CarsIsland.EventBus.Services
{
    public class EventSenderService : IEventSenderService
    {
        private readonly ServiceBusSender _serviceBusSender;
        private readonly ILogger<EventSenderService> _logger;

        public EventSenderService(ServiceBusSender serviceBusSender,
                                     ILogger<EventSenderService> logger)
        {
            _serviceBusSender = serviceBusSender;
            _logger = logger;
        }

        public async Task PublishEventAsync(IntegrationEvent @event)
        {
            try
            {
                var correlationId = Guid.NewGuid().ToString("N");
                var messageToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));
                var message = new ServiceBusMessage(messageToSend)
                {
                    ContentType = $"{System.Net.Mime.MediaTypeNames.Application.Json};charset=utf-8",
                    CorrelationId = correlationId
                };
                await _serviceBusSender.SendAsync(message);
            }

            catch (ServiceBusException ex)
            {
                _logger.LogError($"{nameof(ServiceBusException)} - error details: {ex.Message}");
                throw;
            }
        }
    }
}
