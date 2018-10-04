using Fusca.Domain.Adapters;
using Fusca.Domain.Exceptions;
using Fusca.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otc.AspNetCore.ApiBoot;
using Otc.DomainBase.Exceptions;
using System;
using System.Threading.Tasks;

namespace Fusca.WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class FilmesController : ApiController
    {
        private readonly ITmdbAdapter tmdbAdapter;

        public FilmesController(ITmdbAdapter tmdbAdapter)
        {
            this.tmdbAdapter = tmdbAdapter ?? throw new ArgumentNullException(nameof(tmdbAdapter));
        }

        /// <summary>
        /// Pesquisa por filmes.
        /// </summary>
        /// <param name="pesquisa">Termo a ser pesquisado.</param>
        /// <response code="200">Lista de resultados.</response>
        /// <response code="400">Parametros incorretos ou limite de utilização excedido.</response>
        /// <response code="500">Erro interno.</response>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(GetFilmesResult), 200)]
        [ProducesResponseType(typeof(BuscarFilmesCoreException), 400)]
        [ProducesResponseType(typeof(InternalError), 500)]
        public async Task<IActionResult> GetFilmesAsync(string pesquisa)
        {
            return Ok(await tmdbAdapter.GetFilmesAsync(pesquisa));
        }
    }
}
