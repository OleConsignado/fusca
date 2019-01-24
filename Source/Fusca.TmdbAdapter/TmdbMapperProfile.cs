using AutoMapper;
using Fusca.Domain.Models;
using Fusca.TmdbAdapter.Clients;

namespace Fusca.TmdbAdapter
{
    public class TmdbMapperProfile : Profile
    {
        public TmdbMapperProfile()
        {
            CreateMap<TmdbSearchMoviesGetResult.ResultItem, FilmesGetResult>()
                // Mapeia a propriedade TmdbMovieResult.Overview para GetMoviesResult.Descricao.
                .ForMember(destino => destino.Descricao, opt => opt.MapFrom(origem => origem.Overview))
                // TmdbMovieResult.Title -> GetMoviesResult.Nome
                .ForMember(destino => destino.Nome, opt => opt.MapFrom(origem => origem.Title))
                // TmdbMovieResult.ReleaseDate -> GetMoviesResult.DataLancamento
                .ForMember(destino => destino.DataLancamento, opt => opt.MapFrom(origem => origem.ReleaseDate));

            CreateMap<FilmesGet, TmdbSearchMoviesGet>()
                // FilmesGet.TermoPesquisa -> TmdbSearchMoviesGet.Query
                .ForMember(destino => destino.Query, opt => opt.MapFrom(origem => origem.TermoPesquisa))
                // FilmesGet.AnoLancamento -> TmdbSearchMoviesGet.Year
                .ForMember(destino => destino.Year, opt => opt.MapFrom(origem => origem.AnoLancamento));
        }
    }
}
