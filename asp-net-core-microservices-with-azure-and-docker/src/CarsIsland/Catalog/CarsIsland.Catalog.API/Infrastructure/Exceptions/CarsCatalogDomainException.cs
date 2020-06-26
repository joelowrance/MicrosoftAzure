using System;

namespace CarsIsland.Catalog.API.Infrastructure.Exceptions
{
    public class CarsCatalogDomainException : Exception
    {
        public CarsCatalogDomainException()
        { }

        public CarsCatalogDomainException(string message)
            : base(message)
        { }

        public CarsCatalogDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
