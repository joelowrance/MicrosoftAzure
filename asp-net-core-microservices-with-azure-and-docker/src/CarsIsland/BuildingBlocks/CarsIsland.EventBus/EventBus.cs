using CarsIsland.EventBus.Events;
using CarsIsland.EventBus.Events.Interfaces;
using CarsIsland.EventBus.Services.Interfaces;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CarsIsland.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly SubscriptionClient _subscriptionClient;
        private readonly IEventBusSubscriptionsManager _subscriptionManager;
        private readonly IServiceBusConnectionManagementService _serviceBusConnectionManagementService;
        private readonly ILogger<EventBus> _logger;
        private const string INTEGRATION_EVENT_SUFFIX = "IntegrationEvent";

        public EventBus(IServiceBusConnectionManagementService serviceBusConnectionManagementService,
                        IEventBusSubscriptionsManager subscriptionManager,
                        ILogger<EventBus> logger,
                        string subscriptionClientName)
        {
            _serviceBusConnectionManagementService = serviceBusConnectionManagementService;
            _subscriptionManager = subscriptionManager;
            _subscriptionClient = _subscriptionClient = new SubscriptionClient(_serviceBusConnectionManagementService.ServiceBusConnectionStringBuilder,
                subscriptionClientName);
            _logger = logger;
        }

        public async Task Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name.Replace(INTEGRATION_EVENT_SUFFIX, "");
            var jsonMessage = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            var message = new Message
            {
                MessageId = Guid.NewGuid().ToString(),
                Body = body,
                Label = eventName,
            };

            var topicClient = _serviceBusConnectionManagementService.CreateTopicClient();
            await topicClient.SendAsync(message);
        }

        public async Task Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = typeof(T).Name.Replace(INTEGRATION_EVENT_SUFFIX, "");

            var containsKey = _subscriptionManager.HasSubscriptionsForEvent<T>();
            if (!containsKey)
            {
                try
                {
                    await _subscriptionClient.AddRuleAsync(new RuleDescription
                    {
                        Filter = new CorrelationFilter { Label = eventName },
                        Name = eventName
                    });
                }
                catch (ServiceBusException)
                {
                    _logger.LogWarning("The messaging entity '{eventName}' already exists.", eventName);
                }
            }

            _logger.LogInformation("Subscribing to event '{EventName}' with '{EventHandler}'", eventName, typeof(TH).Name);
            _subscriptionManager.AddSubscription<T, TH>();
        }

        public async Task Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = typeof(T).Name.Replace(INTEGRATION_EVENT_SUFFIX, "");

            try
            {
                await _subscriptionClient.RemoveRuleAsync(eventName);
            }
            catch (MessagingEntityNotFoundException)
            {
                _logger.LogWarning("The messaging entity '{eventName}' Could not be found.", eventName);
            }

            _logger.LogInformation("Unsubscribing from event '{EventName}'", eventName);
            _subscriptionManager.RemoveSubscription<T, TH>();
        }
    }
}
