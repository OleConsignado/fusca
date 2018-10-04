using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusca.Tmdb.Adapter.Adaptee
{
    /// <summary>
    /// Esta interface representa o cliente da API TMDb. 
    /// A sua implementacao eh gerada automaticamente com base nas decoracoes.
    /// A biblioteca Refit eh responsavel pela geracao do codigo (https://github.com/reactiveui/refit).
    /// </summary>
    internal interface ITmdbApi
    {
        [Get("/search/movie")]
        Task<TmdbDiscoverResult> GetUpcommingMoviesAsync(
            [Query] string query,
            [Query, AliasAs("api_key")] string apiKey,
            [Query] string language);
    }
}
