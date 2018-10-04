using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Fusca.Tmdb.Adapter;
using Otc.AspNetCore.ApiBoot;
using Otc.Extensions.Configuration;

namespace Fusca.WebApi
{
    public class Startup : ApiBootStartup
    {
        protected override ApiMetadata ApiMetadata => new ApiMetadata()
        {
            Name = "Documentos do Olé Open API",
            Description = "API de documentos para acesso às Open APIs do Olé",
            DefaultApiVersion = "1.0"
        };

        public Startup(IConfiguration configuration)
            : base(configuration)
        {

        }

        protected override void ConfigureApiServices(IServiceCollection services)
        {
            services.AddTmdbAdapter(Configuration.SafeGet<TmdbAdapterConfiguration>());
        }
    }
}
