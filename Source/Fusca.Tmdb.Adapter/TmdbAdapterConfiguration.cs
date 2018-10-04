using Otc.ComponentModel.DataAnnotations;

namespace Fusca.Tmdb.Adapter
{
    public class TmdbAdapterConfiguration
    {
        [Required]
        public string TmdbApiUrlBase { get; set; }

        [Required]
        public string TmdbApiKey { get; set; }

        public int TempoDeCacheDaPesquisaEmSegundos { get; set; } = 3600;
    }
}
