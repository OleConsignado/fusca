using AutoMapper;
using Fusca.Domain.Models;
using Fusca.Tmdb.Adapter.Adaptee;

namespace Fusca.Tmdb.Adapter
{
    public class TmdbMapperProfile : Profile
    {
        public TmdbMapperProfile()
        {
            CreateMap<TmdbDiscoverResult.ResultItem, GetFilmesResult>()
                // Mapeia a propriedade TmdbMovieResult.Overview para GetMoviesResult.Descricao.
                .ForMember(destino => destino.Descricao, opt => opt.MapFrom(origem => origem.Overview))
                // TmdbMovieResult.Title -> GetMoviesResult.Nome
                .ForMember(destino => destino.Nome, opt => opt.MapFrom(origem => origem.Title));
        }
    }
}
