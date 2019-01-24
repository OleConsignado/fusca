using Fusca.Domain.Adapters;
using Fusca.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using Otc.AspNetCore.ApiBoot.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Fusca.WebApi.Tests.v1
{
    public class FilmesTests : IClassFixture<HttpFixture<TestsStartup>>
    {
        private const string apiVersion = "1.0";
        private readonly HttpFixture<TestsStartup> httpFixture;

        public FilmesTests(HttpFixture<TestsStartup> httpFixture)
        {
            this.httpFixture = httpFixture ?? throw new ArgumentNullException(nameof(httpFixture));
        }

        [Fact]
        public async Task Test_Pesquisa_ParametroInvalido()
        {
            var tmdbAdapterMock = new Mock<ITmdbAdapter>();

            var httpClient = CreateHttpClient(tmdbAdapterMock);

            // Realiza uma requisicao HTTP GET na rota {httpClient.BaseAddress}/filmes
            var response = await httpClient.GetAsync("filmes");

            // Verifica se a resposta esta de acordo com o esperado.
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            // TODO: Avaliar melhor forma de obter o erro (necessario um DTO?)
            //var responseText = await response.Content.ReadAsStringAsync();
            //var ex = JsonConvert.DeserializeObject<BuscarFilmesCoreException>(responseText);
            //Assert.Equal(BuscarFilmesCoreError.ParametrosIncorretos.Key, ex.Errors.Single().Key);
        }

        [Fact]
        public async Task Test_Pesquisa()
        {
            // Objeto que sera utilizado para retorno do Mock
            var expected = new List<FilmesGetResult>()
                {
                    new FilmesGetResult()
                    {
                        Id = 10447,
                        Descricao = "descricao_teste",
                        Nome = "nome_teste"
                    }
                };

            var tmdbAdapterMock = new Mock<ITmdbAdapter>();

            // Configura o Mock
            tmdbAdapterMock
                .Setup(m => m.GetFilmesAsync(It.IsAny<FilmesGet>()))
                .ReturnsAsync(expected);

            var httpClient = CreateHttpClient(tmdbAdapterMock);

            // Realiza uma requisicao HTTP GET na rota {httpClient.BaseAddress}/filmes?termoPesquisa=teste&anoLancamento=2000
            var response = await httpClient.GetAsync("filmes?termoPesquisa=teste&anoLancamento=2000");

            // Verifica se a resposta esta de acordo com o esperado.
            Assert.True(response.IsSuccessStatusCode);
            var responseText = await response.Content.ReadAsStringAsync();
            var filmes = JsonConvert.DeserializeObject<IEnumerable<FilmesGetResult>>(responseText);
            Assert.Contains(filmes, f => f.Id == expected.Single().Id);
        }

        // TODO: avaliar a possibilidade de levar para Otc.AspNetCore.ApiBoot.TestHost
        private HttpClient CreateHttpClient(params Mock[] mocks)
        {
            var httpClient = httpFixture
                // cria o servidor http de teste (TestServer)
                .CreateServer(services =>
                {
                    // O TestsStartup.ConfigureApiServices foi sobreescrito
                    // para prevenir o registro das dependencias da API (neste caso, a camada Fusca.TmdbAdapter).
                    // Aqui registramos os Mocks como dependencias para que os testes possam ser executados
                    // sem dependencias externas.

                    foreach (var mock in mocks)
                    {
                        if (mock.GetType().GetGenericTypeDefinition() != typeof(Mock<>))
                        {
                            throw new InvalidOperationException("Mock object should be of type Mock<T>");
                        }

                        services.AddScoped(mock.GetType().GetGenericArguments().Single(), c => mock.Object);
                    }
                })
                // cria um HttpClient que consome o servidor de teste.
                .CreateClient();

            // Adiciona o segmento da versao ao endereco base (vai ficar algo parecido com http://localhost:54577/v1/)
            httpClient.BaseAddress = new Uri(httpClient.BaseAddress, $"v{apiVersion}/");

            return httpClient;
        }
    }
}
