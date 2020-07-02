using CarsIsland.Catalog.API.Core.IntegrationEvents;
using CarsIsland.Catalog.API.Core.IntegrationEvents.Interfaces;
using CarsIsland.EventLog.Services;
using CarsIsland.EventLog.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Common;

namespace CarsIsland.Catalog.API.Core.DependencyInjection
{
    public static class IntegrationServiceCollectionExtensions
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddTransient<Func<DbConnection, IEventLogService>>(
                    sp => (DbConnection connection) => new EventLogService(connection));

            services.AddTransient<ICatalogIntegrationEventService, CatalogIntegrationEventService>();

            return services;
        }
    }
}
