using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otc.AspNetCore.ApiBoot;

namespace Fusca.WebApi.Tests
{
    public class TestsStartup : ApiBootStartup
    {
        public TestsStartup(IConfiguration configuration)
            : base(configuration)
        {

        }

        protected override ApiMetadata ApiMetadata => new ApiMetadata()
        {
            Name = "Documentos do Olé Open API",
            Description = "API de documentos para acesso às Open APIs do Olé",
            DefaultApiVersion = "1.0"
        };

        protected override void ConfigureApiServices(IServiceCollection services)
        {
            // Prevent default service registration by leaving this empty;
            // Services registration should be done at HttpFixture.CreateServer.  
        }
    }
}
