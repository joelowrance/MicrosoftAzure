using CarsIsland.Catalog.Domain.Repositories.Interfaces;
using CarsIsland.Catalog.Infrastructure.Configuration.Interfaces;
using CarsIsland.Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarsIsland.Catalog.API.Core.DependencyInjection
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataService(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var sqlDbConfiguration = serviceProvider.GetRequiredService<ISqlDbDataServiceConfiguration>();

            services.AddDbContext<CarCatalogDbContext>(c =>
               c.UseSqlServer(sqlDbConfiguration.ConnectionString));

            services.AddScoped<ICarsCatalogRepository, CarCatalogRepository>();

            return services;
        }
    }
}
