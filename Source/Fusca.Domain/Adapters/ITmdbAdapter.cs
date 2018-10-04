using Fusca.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusca.Domain.Adapters
{
    public interface ITmdbAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Lista com os filmes mais recentes</returns>
        /// <exception cref="Exceptions.BuscarFilmesCoreException" />
        Task<IEnumerable<GetFilmesResult>> GetFilmesAsync(string query);
    }
}
