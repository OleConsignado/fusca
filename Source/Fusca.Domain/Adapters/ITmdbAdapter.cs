using Fusca.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusca.Domain.Adapters
{
    public interface ITmdbAdapter
    {
        /// <summary>
        /// Realiza pesquisa em filmes.
        /// </summary>
        /// <param name="filmesGet">Criterios de pesquisa.</param>
        /// <returns>Lista dos filmes encontrados conforme criterio de pesquisa.</returns>
        /// <exception cref="Exceptions.BuscarFilmesCoreException" />
        Task<IEnumerable<FilmesGetResult>> GetFilmesAsync(FilmesGet filmesGet);
    }
}
