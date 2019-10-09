using Fusca.Domain.Adapters;
using Fusca.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otc.AspNetCore.ApiBoot;
using Otc.DomainBase.Exceptions;
using Otc.Validations.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusca.WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class FilmesController : ApiController
    {
        private readonly ITmdbAdapter tmdbAdapter;
        private readonly ILogger logger;

        public FilmesController(ITmdbAdapter tmdbAdapter, ILoggerFactory loggerFactory)
        {
            this.tmdbAdapter = tmdbAdapter ??
                throw new ArgumentNullException(nameof(tmdbAdapter));
            logger = loggerFactory?.CreateLogger<FilmesController>() ??
                throw new ArgumentNullException(nameof(loggerFactory));
        }

        /// <summary>
        /// Pesquisa por filmes.
        /// </summary>
        /// <param name="filmesGet">Criterios de pesquisa na base de filmes.</param>
        /// <response code="200">Lista de resultados.</response>
        /// <response code="400">Parametros incorretos ou limite de utilização excedido.</response>
        /// <response code="500">Erro interno.</response>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<FilmesGetResult>), 200)]
        [ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        [ProducesResponseType(typeof(InternalError), 500)]
        public async Task<IActionResult> GetFilmesAsync([FromQuery] FilmesGet filmesGet)
        {
            ValidationHelper.ThrowValidationExceptionIfNotValid(filmesGet);
            logger.LogInformation("Realizando chamada ao TMDb com os seguintes " +
                            "criterios de pesquisa: {@CriteriosPesquisa}", filmesGet);
            IEnumerable<FilmesGetResult> resultado = await tmdbAdapter.GetFilmesAsync(filmesGet);
            logger.LogInformation("Chamada ao TMDb concluida com sucesso.");

            return Ok(resultado);
        }
    }
}
