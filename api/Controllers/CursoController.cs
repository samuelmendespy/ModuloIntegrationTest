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
    public class CursoController : ControllerBase
    {
        private readonly EscolaContext _context;
        public CursoController(
            EscolaContext context;
        )
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var curso = _context.Cursos.Find(id);
            if (curso == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(curso);
            }
        }

        [HttpGet("ObterTudo")]
        public IActionResult ObterTudo()
        {
            var cursos = _context.Cursos.ToList();
            if (cursos == null || cursos.Count == 0)
            {
                return NotFound("Tarefas não encontradas");
            }

            return Ok(cursos);
        }

        [HttpPost]
        public IActionResult Criar(Curso curso)
        {
            if (string.IsNullOrEmpty(curso.Nome))
            {
                return BadRequest(new { Erro = "O nome do curso não pode estar vazio!" });
            }
 
            _context.Add(curso);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(ObterPorId), new { id = curso.Id }, curso);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var cursoBanco = _context.Cursos.Find(id);

            if (cursoBanco == null)
            {
                return NotFound();
            }

            _context.Cursos.Remove(cursoBanco);
            _context.SaveChanges();

            return NoContent();
        }

        
    }
}