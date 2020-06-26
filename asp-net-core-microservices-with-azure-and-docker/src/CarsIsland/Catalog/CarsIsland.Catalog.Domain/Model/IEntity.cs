using System;

namespace CarsIsland.Catalog.Domain.Model
{
    internal interface IEntity
    {
        public Guid Id { get; set; }
    }
}
