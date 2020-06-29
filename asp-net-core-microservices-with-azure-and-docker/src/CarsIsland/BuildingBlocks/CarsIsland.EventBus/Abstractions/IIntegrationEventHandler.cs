using CarsIsland.EventBus.Events;
using System.Threading.Tasks;

namespace CarsIsland.EventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent>
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }
}
