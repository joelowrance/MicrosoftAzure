using CarsIsland.EventBus.Events;
using System.Threading.Tasks;

namespace CarsIsland.EventBus.Services.Interfaces
{
    public interface IEventSenderService
    {
        Task PublishEventAsync(IntegrationEvent @event);
    }
}
