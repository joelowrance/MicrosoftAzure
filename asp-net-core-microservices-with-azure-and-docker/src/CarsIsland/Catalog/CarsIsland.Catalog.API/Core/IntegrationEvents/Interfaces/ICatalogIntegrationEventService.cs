using CarsIsland.EventBus.Events;
using System.Threading.Tasks;

namespace CarsIsland.Catalog.API.Core.IntegrationEvents.Interfaces
{
    public interface ICatalogIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(IntegrationEvent @event);
        Task AddAndSaveEventAsync(IntegrationEvent @event);
    }
}
