using System;
using System.Collections.Generic;

namespace CarsIsland.Reservation.Domain.Model
{
    public class CustomerReservation
    {
        public Guid CustomerId { get; set; }
        public List<Car> Cars { get; set; }

        public CustomerReservation(Guid customerId)
        {
            CustomerId = customerId;
            Cars = new List<Car>();
        }
    }
}
