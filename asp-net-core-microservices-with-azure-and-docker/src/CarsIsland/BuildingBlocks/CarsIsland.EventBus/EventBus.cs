using CarsIsland.EventBus.Events;
using CarsIsland.EventBus.Events.Interfaces;
using CarsIsland.EventBus.Services.Interfaces;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;

namespace CarsIsland.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly SubscriptionClient _subscriptionClient;
        private readonly IServiceBusConnectionManagementService _serviceBusConnectionManagementService;
        private readonly ILogger<EventBus> _logger;
        private const string INTEGRATION_EVENT_SUFFIX = "IntegrationEvent";

        public EventBus(IServiceBusConnectionManagementService serviceBusConnectionManagementService,
                                     ILogger<EventBus> logger,
                                     string subscriptionClientName)
        {
            _serviceBusConnectionManagementService = serviceBusConnectionManagementService;
            _subscriptionClient = _subscriptionClient = new SubscriptionClient(_serviceBusConnectionManagementService.ServiceBusConnectionStringBuilder,
                subscriptionClientName);
            _logger = logger;
        }

        public void Publish(IntegrationEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}
