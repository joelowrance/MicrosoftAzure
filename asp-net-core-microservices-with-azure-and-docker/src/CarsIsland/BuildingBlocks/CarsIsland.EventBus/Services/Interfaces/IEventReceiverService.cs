using System.Threading;
using System.Threading.Tasks;

namespace CarsIsland.EventBus.Services.Interfaces
{
    public interface IEventReceiverService
    {
        Task ReceiveEventAsync(CancellationToken cancellationToken);
    }
}
