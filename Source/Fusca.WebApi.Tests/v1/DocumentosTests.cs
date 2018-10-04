using Otc.AspNetCore.ApiBoot.TestHost;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Fusca.WebApi.Tests.v1
{
    public class DocumentosTests : IClassFixture<HttpFixture<TestsStartup>>
    {
        private readonly HttpFixture<TestsStartup> httpFixture;

        public DocumentosTests(HttpFixture<TestsStartup> httpFixture)
        {
            this.httpFixture = httpFixture ?? throw new ArgumentNullException(nameof(httpFixture));
        }

        [Fact]
        public async Task Teste_Exemplo()
        {
            await Task.CompletedTask;

            Assert.True(true);
        }
    }
}
