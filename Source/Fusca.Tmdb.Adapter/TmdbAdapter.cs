using AutoMapper;
using Fusca.Domain.Adapters;
using Fusca.Domain.Exceptions;
using Fusca.Domain.Models;
using Fusca.Tmdb.Adapter.Adaptee;
using Otc.Caching.Abstractions;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Fusca.Tmdb.Adapter
{
    internal class TmdbAdapter : ITmdbAdapter
    {
        private readonly ITmdbApi tmdbApi;
        private readonly TmdbAdapterConfiguration tmdbAdapterConfiguration;
        private readonly ITypedCache typedCache;

        public TmdbAdapter(ITmdbApi tmdbApi, 
            TmdbAdapterConfiguration tmdbAdapterConfiguration, 
            ITypedCache typedCache)
        {
            this.tmdbApi = tmdbApi ?? throw new ArgumentNullException(nameof(tmdbApi));
            this.tmdbAdapterConfiguration = tmdbAdapterConfiguration ?? throw new ArgumentNullException(nameof(tmdbAdapterConfiguration));
            this.typedCache = typedCache ?? throw new ArgumentNullException(nameof(typedCache));
        }

        public async Task<IEnumerable<GetFilmesResult>> GetFilmesAsync(string query)
        {
            try
            {
                var cacheKey = $"filmes::{query}";

                if(!typedCache.TryGet(cacheKey, out TmdbDiscoverResult tmdbDiscoverResult))
                {
                    tmdbDiscoverResult = await tmdbApi.GetUpcommingMoviesAsync(query, tmdbAdapterConfiguration.TmdbApiKey, tmdbAdapterConfiguration.Idioma);
                    typedCache.Set(cacheKey, tmdbDiscoverResult, TimeSpan.FromSeconds(tmdbAdapterConfiguration.TempoDeCacheDaPesquisaEmSegundos));
                }

                return Mapper.Map<IEnumerable<GetFilmesResult>>(tmdbDiscoverResult.Results);
            }
            catch (ApiException e)
            {
                switch (e.StatusCode)
                {
                    case (HttpStatusCode)429: // TooManyRequests
                        throw new BuscarFilmesCoreException(
                            BuscarFilmesCoreError.LimiteDeRequisicoesAtingido);

                    // Parametros incorretos (https://www.themoviedb.org/documentation/api/status-codes)
                    case (HttpStatusCode)422: 
                        throw new BuscarFilmesCoreException(
                            BuscarFilmesCoreError.ParametrosIncorretos);
                }

                throw;
            }
        }
    }
}
