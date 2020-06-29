using CarsIsland.EventBus.Abstractions;
using CarsIsland.EventBus.Events;
using CarsIsland.EventBus.Services.Interfaces;
using System;

namespace CarsIsland.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly IEventReceiverService _eventReceiverService;
        private readonly IEventSenderService _eventSenderService;

        public EventBus(IEventReceiverService eventReceiverService, IEventSenderService eventSenderService)
        {
            _eventReceiverService = eventReceiverService;
            _eventSenderService = eventSenderService;
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
