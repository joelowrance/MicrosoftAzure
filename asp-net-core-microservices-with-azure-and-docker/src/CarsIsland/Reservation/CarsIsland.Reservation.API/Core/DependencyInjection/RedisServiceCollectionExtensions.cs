using CarsIsland.Reservation.Infrastructure.Configuration.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CarsIsland.Reservation.API.Core.DependencyInjection
{
    public static class RedisServiceCollectionExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services)
        {
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var redisConfiguration = sp.GetRequiredService<IRedisConfiguration>();
                var configuration = ConfigurationOptions.Parse(redisConfiguration.ConnectionString, true);
                configuration.ResolveDns = true;
                return ConnectionMultiplexer.Connect(configuration);
            });
            return services;
        }
    }
}
