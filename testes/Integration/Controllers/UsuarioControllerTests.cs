using api.ViewModels.Usuarios;
using api;
using testes.Configurations;
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
            var cadastrarUsuarioViewModelInput = new CadastrarUsuarioViewModelInput
            {
                Nome = "Unnamed Student",
                Telefone = "40028922",
                Ativo = true
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(cadastrarUsuarioViewModelInput), Encoding.UTF8, "application/json");

            // Act
            var httpClientRequest = _httpClient.PostAsync("api/Usuario/registrar", content ).GetAwaiter().GetResult();

            CadastrarUsuarioViewModelOutput = JsonConvert.DeserializeObject<CadastrarUsuarioViewModelOutput>(await httpClientRequest.Content.ReadAsStringAsync());
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, httpClientRequest.StatusCode);
            Assert.NotNull(CadastrarUsuarioViewModelOutput);
            Assert.Equal(cadastrarUsuarioViewModelInput.Nome, CadastrarUsuarioViewModelOutput?.Nome);
            _output.WriteLine($"{nameof(UsuarioControllerTests)}_{nameof(CadastrarUsuario_InformandoNomeTeloneEAtivo_DeveRetronarSucesso)} = {await httpClientRequest.Content.ReadAsStringAsync()}");
        }
    }
}