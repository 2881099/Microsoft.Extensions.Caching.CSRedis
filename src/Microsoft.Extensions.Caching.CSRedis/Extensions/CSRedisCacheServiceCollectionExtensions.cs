using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using System;
using Microsoft.Extensions.Caching.CSRedis;

namespace Microsoft.Extensions.DependencyInjection
{

    public static class CSRedisCacheServiceCollectionExtensions
    {

        /// <summary>
        /// Adds CSRedis distributed caching services to the specified <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /> to add services to.</param>
        /// <param name="setupAction">An <see cref="T:System.Action`1" /> to configure the provided
        /// <see cref="T:Microsoft.Extensions.Caching.Redis.RedisCacheOptions" />.</param>
        /// <returns>The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /> so that additional calls can be chained.</returns>
        public static IServiceCollection AddDistributedCSRedisCache(this IServiceCollection services, Action<RedisCacheOptions> setupAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));
            services.AddOptions();
            services.Configure(setupAction);
            services.Add(ServiceDescriptor.Singleton<IDistributedCache, CSRedisCache>());
            return services;
        }

    }

}