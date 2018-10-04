using System;
using System.Collections.Generic;
using System.Text;

namespace Fusca.Tmdb.Adapter.Adaptee
{
    /// <summary>
    /// <para>
    /// Este modelo representa exatamente o retorno da rota search/movie API TMDb e
    /// eh o retorno do metodo <see cref="ITmdbApi.GetUpcommingMoviesAsync"/>.
    /// O Refit implementa a deserializacao do resultado da chamada para esta estrutura.
    /// </para>
    /// <para>    
    /// Note que esta classe eh interna ao Adaptador, 
    /// os dados serao mapeados para <see cref="Domain.Models.GetFilmesResult" /> para ser exposto.
    /// O mapeamento eh feito em <see cref="TmdbAdapter.GetFilmesAsync"/>.
    /// </para>
    /// </summary>
    internal class TmdbDiscoverResult
    {
        internal class ResultItem
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Overview { get; set; }
        }

        public IEnumerable<ResultItem> Results { get; set; }
    }
}
