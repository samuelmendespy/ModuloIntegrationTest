using api.ViewModels.Usuarios;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace testes.Integration.Controllers
{
    public class UsuarioControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        protected readonly HttpClient _httpClient;
        protected CadastrarUsuarioViewModelnput? CadastrarUsuarioViewModelnput;
        protected CadastrarUsuarioViewModelnput? CadastrarUsuarioViewModeOutput;
        public UsuarioControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        // public void Cadastrar_InserindoUsuarioComNomeETelefoneEAtivo_DeveRetornarSucesso()

        [Fact]
        public void CadastrarUsuarioTest()
        { 

            //Arrange
            var cadastrarUsuarioViewModelnput = new CadastrarUsuarioViewModelnput
            {
                Nome = "Unnamed Student",
                Telefone = "40028922",
                Ativo = true
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(cadastrarUsuarioViewModelnput), Encoding.UTF8, "application/json");

            // Act
            var httpClientRequest = _httpClient.PostAsync("api/Usuario/registrar", content ).GetAwaiter().GetResult();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, httpClientRequest.StatusCode);
        }
    }
}