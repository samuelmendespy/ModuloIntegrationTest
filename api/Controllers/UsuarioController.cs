using api.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        // private readonly IUsuarioRepository _usuarioRepository;
        private readonly EscolaContext _context;
        public UsuarioController(
            // IUsuarioRepository _usuarioRepository,
            EscolaContext context;
        )
        {
            // _usuarioRepository,
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();

            return CreatedAction(nameof(ObterPorId), new {id = usuario.Id}, usuario)
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var usuario = _context.Usuarios.Where(x => x.Nome.Equals(nome));
            return Ok(usuario);
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario )
        {
            var usuarioBanco = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Telefone = usuario.Telefone;
            usuarioBanco.Ativo = usuario.Ativo;

            _context.Usuarios.Update(usuarioBanco);
            _context.SaveChanges();

            return Ok(usuarioBanco); 
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var contatoBanco = _context.Usuarios.Find(id);
            
            if (contatoBanco == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(contatoBanco);
            _context.SaveChanges();

            return NoContent();
        }

    }
}