using System;

namespace CarsIsland.Reservation.API.Services.Interfaces
{
    interface IIdentityService
    {
        Guid GetUserIdentity();
    }
}
