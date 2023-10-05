using api.Models;
using api.DTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SQLitePCL;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            IUsuarioService usuarioService,
            ILogger<UsuarioController> logger
            )
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var usuario = _usuarioService.ObterUsuarioPorNome(nome);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UsuarioDTO usuarioDTO )
        {
            var usuarioBanco = _usuarioService.ObterUsuarioPorId(id);

            if (usuarioBanco == null)
            {
                return NotFound();
            }

            usuarioBanco.Nome = usuarioDTO.Nome;
            usuarioBanco.Telefone = usuarioDTO.Telefone;
            usuarioBanco.Ativo = usuarioDTO.Ativo;

            _usuarioService.AtualizarUsuario(usuarioBanco);

            return Ok(usuarioBanco); 
        }
        
        /// <summary>
        /// Este serviço permite cadastrar um usuário cadastrado não existente.
        /// </summary>
        [HttpPost]
        public IActionResult Criar(UsuarioDTO usuarioDTO)
        {
            var usuario = _usuarioService.CriarUsuario(usuarioDTO);

            return CreatedAtAction(nameof(ObterPorId), new {id = usuario.Id}, usuario);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(UsuarioDTO usuarioDTO)
        {
            try
            {
            var usuario = _usuarioService.CriarUsuario(usuarioDTO);
            return Ok(usuario);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var contatoBanco = _usuarioService.ObterUsuarioPorId(id);
            
            if (contatoBanco == null)
            {
                return NotFound();
            }

            _usuarioService.DeletarUsuario(id);

            return NoContent();
        }

    }
}