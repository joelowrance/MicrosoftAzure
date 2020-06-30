using CarsIsland.EventBus.Events;

namespace CarsIsland.Rent.API.Core.IntegrationEvents.Events
{
    public class CarRentConfirmedAndPaidIntegrationEvent : IntegrationEvent
    {
        public string UserId { get; set; }

        public CarRentConfirmedAndPaidIntegrationEvent(string userId)
            => UserId = userId;
    }
}
