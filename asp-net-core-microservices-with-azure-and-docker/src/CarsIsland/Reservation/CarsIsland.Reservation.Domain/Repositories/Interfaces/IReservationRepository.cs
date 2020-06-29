using CarsIsland.Reservation.Domain.Model;
using System;
using System.Threading.Tasks;

namespace CarsIsland.Reservation.Domain.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        Task<CustomerReservation> GetReservationAsync(Guid customerId);
        Task<CustomerReservation> UpdateReservationAsync(CustomerReservation reservation);
        Task<bool> DeleteReservationAsync(Guid id);
    }
}
