using Otc.ComponentModel.DataAnnotations;

namespace Fusca.Domain.Models
{
    public class FilmesGet
    {
        /// <summary>
        /// Termo a ser pesquisado.
        /// </summary>
        [Required(ErrorKey = "TermoPesquisaObrigatorio")]
        public string TermoPesquisa { get; set; }

        /// <summary>
        /// Ano de lançamento.
        /// </summary>
        public int? AnoLancamento { get; set; }
    }
}
