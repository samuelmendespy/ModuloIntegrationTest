using api.ViewModels.Usuarios;
using Microsoft.AspNetCore.Hosting;
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
            HttpClient _httpClient = _factory.CreateClient();
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

            // Newtonsoft Serialize
            // string serialized  = JsonConvert.SerializeObject(cadastrarUsuarioViewModelnput);
            // StringContent content = new StringContent(serialized , Encoding.UTF8, "application/json");
            
            _httpClient.PostAsync("api/Usuario", content );
            // Deserialize
            // string json = "{\"Nome\":\"John Doe\",\"Telefone\":\"123456789\",\"Ativo\":true}";
            // CadastrarUsuarioViewModelnput result = JsonConvert.DeserializeObject<CadastrarUsuarioViewModelnput>(json);
        }
    }
}