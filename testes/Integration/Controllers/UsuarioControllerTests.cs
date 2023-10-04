using api.ViewModels.Usuarios;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace testes.Integration.Controllers
{
    public class UsuarioControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;
        protected readonly HttpClient _httpClient;


        public UsuarioControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        public void Cadastrar()
        {
            var cadastrarUsuarioViewModelnput = new CadastrarUsuarioViewModelnput
            {
                Nome = "Unnamed Student",
                Telefone = "40028922",
                Ativo = true
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(cadastrarUsuarioViewModelnput));

            var httpClientRequest = _httpClient.PostAsync("api/Usuario", content ).GetAwaiter().GetResult();

            Assert.Equal(System.Net.HttpStatusCode.OK, httpClientRequest.StatusCode);
           
        }
    }
}