using CarsIsland.Reservation.Domain.Model;
using CarsIsland.Reservation.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace CarsIsland.Reservation.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ILogger<ReservationRepository> _logger;
        private readonly IDatabase _database;

        public ReservationRepository(ILogger<ReservationRepository> logger,
                                     IDatabase database)
        {
            _logger = logger;
            _database = database;
        }

        public async Task<bool> DeleteReservationAsync(Guid id)
        {
            return await _database.KeyDeleteAsync(id.ToString());
        }

        public async Task<CustomerReservation> GetReservationAsync(Guid customerId)
        {
            var data = await _database.StringGetAsync(customerId.ToString());

            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CustomerReservation>(data);
        }

        public async Task<CustomerReservation> UpdateReservationAsync(CustomerReservation reservation)
        {
            var created = await _database.StringSetAsync(reservation.CustomerId.ToString(),
                                                         JsonConvert.SerializeObject(reservation));

            if (!created)
            {
                _logger.LogInformation("Problem occur persisting the reservation.");
                return null;
            }

            _logger.LogInformation("Reservation persisted succesfully.");

            return await GetReservationAsync(reservation.CustomerId);
        }
    }
}
