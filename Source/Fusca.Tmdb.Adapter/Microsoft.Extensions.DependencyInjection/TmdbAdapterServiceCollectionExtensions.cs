using Fusca.Domain.Adapters;
using Fusca.Tmdb.Adapter;
using Fusca.Tmdb.Adapter.Adaptee;
using Otc.Networking.Http.Client.Abstractions;
using Refit;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TmdbAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddTmdbAdapter(this IServiceCollection services, TmdbAdapterConfiguration tmdbAdapterConfiguration)
        {
            if (tmdbAdapterConfiguration == null)
                throw new ArgumentNullException(nameof(tmdbAdapterConfiguration));

            services.AddSingleton(tmdbAdapterConfiguration);

            services.AddScoped(serviceProvider =>
            {
                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateHttpClient();
                httpClient.BaseAddress = new Uri(tmdbAdapterConfiguration.TmdbApiUrlBase);

                return RestService.For<ITmdbApi>(httpClient);
            });

            services.AddScoped<ITmdbAdapter, TmdbAdapter>();

            return services;
        }
    }
}