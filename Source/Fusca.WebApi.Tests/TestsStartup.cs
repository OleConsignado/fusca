using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otc.AspNetCore.ApiBoot;

namespace Fusca.WebApi.Tests
{
    public class TestsStartup : Startup
    {
        public TestsStartup(IConfiguration configuration)
            : base(configuration)
        {

        }

        protected override void ConfigureApiServices(IServiceCollection services)
        {
            // Prevent default service registration by leaving this empty;
            // Services registration should be done at HttpFixture.CreateServer.  
        }
    }
}
