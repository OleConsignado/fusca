using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusca.Tmdb.Adapter.Adaptee
{
    public interface ITmdbApi
    {
        [Get("search/movie")]
        Task<IEnumerable<MovieResult>> GetUpcommingMoviesAsync();
    }
}
