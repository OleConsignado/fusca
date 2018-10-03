using Otc.ComponentModel.DataAnnotations;

namespace Fusca.Tmdb.Adapter
{
    public class TmdbAdapterConfiguration
    {
        [Required]
        public string ITmdbApiUrlBase { get; set; }

        [Required]
        public string ITmdbApiKey { get; set; }
    }
}
