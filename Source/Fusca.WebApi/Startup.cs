using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Fusca.Tmdb.Adapter;
using Otc.AspNetCore.ApiBoot;
using Otc.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Fusca.WebApi
{
    public class Startup : ApiBootStartup
    {
        protected override ApiMetadata ApiMetadata => new ApiMetadata()
        {
            Name = "Fusca",
            Description = "API de exemplo (Olé Consignado).",
            DefaultApiVersion = "1.0"
        };

        public Startup(IConfiguration configuration)
            : base(configuration)
        {
            Mapper.Reset();

            Mapper.Initialize(config =>
            {
                config.AddProfile<TmdbMapperProfile>();
            });
        }

        [ExcludeFromCodeCoverage]
        protected override void ConfigureApiServices(IServiceCollection services)
        {
            services.AddTmdbAdapter(Configuration.SafeGet<TmdbAdapterConfiguration>());
        }
    }
}
