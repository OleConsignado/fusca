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
                // Mapeia a propriedade TmdbMovieResult.Overview para GetMoviesResult.Description.
                .ForMember(d => d.Descricao, opt => opt.MapFrom(s => s.Overview));
        }
    }
}
