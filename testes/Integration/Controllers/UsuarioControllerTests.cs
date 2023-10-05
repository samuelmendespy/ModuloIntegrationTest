using api.ViewModels.Usuarios;
using api;
using api.Models;
using testes.Configurations;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using Xunit;
using Xunit.Abstractions;


namespace testes.Integration.Controllers
{
    public class UsuarioControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        protected readonly ITestLoggerFactory _output;
        protected readonly HttpClient _httpClient;
        protected CadastrarUsuarioViewModelInput? CadastrarUsuarioViewModelInput;
        protected CadastrarUsuarioViewModelOutput? CadastrarUsuarioViewModelOutput;
        public UsuarioControllerTests(WebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _output = new TestLoggerFactory(output);
            _httpClient = _factory.CreateClient();
        }

        // public void Cadastrar_InserindoUsuarioComNomeETelefoneEAtivo_DeveRetornarSucesso()

        [Fact]
        public async Task CadastrarUsuario_InformandoNomeTeloneEAtivo_DeveRetronarSucesso()
        { 

            //Arrange
            CadastrarUsuarioViewModelInput = new CadastrarUsuarioViewModelInput
            {
                Nome = "Unnamed Student",
                Telefone = "40028922",
                Ativo = true
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(CadastrarUsuarioViewModelInput), Encoding.UTF8, "application/json");

            // Act
            var httpClientRequest = await _httpClient.PostAsync("api/Usuario/cadastrar", content );

            CadastrarUsuarioViewModelOutput = JsonConvert.DeserializeObject<CadastrarUsuarioViewModelOutput>(await httpClientRequest.Content.ReadAsStringAsync());
            // Assert
            Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
            Assert.NotNull(CadastrarUsuarioViewModelOutput);
            Assert.Equal("Unnamed Student", CadastrarUsuarioViewModelOutput?.Nome);
            _output.WriteLine($"{nameof(UsuarioControllerTests)}_{nameof(CadastrarUsuario_InformandoNomeTeloneEAtivo_DeveRetronarSucesso)} = {await httpClientRequest.Content.ReadAsStringAsync()}");
        }

        [Fact]
        public async Task ObterPorNome_InformandoNome_DeveRetornarSucesso()
        {
            // Arrange
            var nomeUsuario = "Unnamed Student";

            // Act
            var httpClientRequest = await _httpClient.GetAsync($"api/Usuario/ObterPorNome?Nome={nomeUsuario}");
            httpClientRequest.EnsureSuccessStatusCode();

            var responseContent = await httpClientRequest.Content.ReadAsStringAsync();
            var usuariosEncontrados = JsonConvert.DeserializeObject<List<Usuario>>(responseContent);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
            Assert.Equal(nomeUsuario, usuariosEncontrados?[0].Nome);
        }
    }
}