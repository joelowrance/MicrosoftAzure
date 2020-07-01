using CarsIsland.EventBus.Events;
using System;
using System.Threading.Tasks;

namespace CarsIsland.Rent.API.Core.IntegrationEvents.Interfaces
{
    public interface IRentalIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent @event);
    }
}
