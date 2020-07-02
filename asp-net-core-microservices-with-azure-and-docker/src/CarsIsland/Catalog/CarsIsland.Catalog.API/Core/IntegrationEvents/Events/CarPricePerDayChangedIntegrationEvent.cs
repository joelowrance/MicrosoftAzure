using CarsIsland.EventBus.Events;
using System;

namespace CarsIsland.Catalog.API.Core.IntegrationEvents.Events
{
    public class CarPricePerDayChangedIntegrationEvent : IntegrationEvent
    {
        public Guid CarId { get; private set; }

        public decimal NewPricePerDay { get; private set; }

        public decimal OldPricePerDay { get; private set; }

        public CarPricePerDayChangedIntegrationEvent(Guid carId, decimal newPrice, decimal oldPrice)
        {
            CarId = carId;
            NewPricePerDay = newPrice;
            OldPricePerDay = oldPrice;
        }
    }
}
