using Fusca.Domain.Adapters;
using Fusca.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otc.AspNetCore.ApiBoot;
using Otc.DomainBase.Exceptions;
using Otc.Validations.Helpers;
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
        /// <param name="filmesGet">Criterios de pesquisa na base de filmes.</param>
        /// <response code="200">Lista de resultados.</response>
        /// <response code="400">Parametros incorretos ou limite de utilização excedido.</response>
        /// <response code="500">Erro interno.</response>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(FilmesGetResult), 200)]
        [ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        [ProducesResponseType(typeof(InternalError), 500)]
        public async Task<IActionResult> GetFilmesAsync([FromQuery] FilmesGet filmesGet)
        {
            ValidationHelper.ThrowValidationExceptionIfNotValid(filmesGet);

            return Ok(await tmdbAdapter.GetFilmesAsync(filmesGet));
        }
    }
}
