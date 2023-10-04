using api.ViewModels.Usuarios;
using api;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace testes.Integration.Controllers
{
    public class UsuarioControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        protected readonly HttpClient _httpClient;
        protected CadastrarUsuarioViewModelnput? CadastrarUsuarioViewModelnput;
        protected CadastrarUsuarioViewModelnput? CadastrarUsuarioViewModeOutput;
        public UsuarioControllerTests(WebApplicationFactory<Startup> factory)
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