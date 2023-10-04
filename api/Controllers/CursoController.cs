using api.Services;
using Microsoft.AspNetCore.Mvc;
using api.DTOs;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var curso = _cursoService.ObterCursoPorId(id);
            if (curso == null)
            {
                return NotFound($"Não foi encontrado o usuário{id}");
            }
            else
            {
                return Ok(curso);
            }
        }
        
        /// <summary>
        /// Este serviço permite obter todos os cursos.
        /// </summary>
        /// <returns>Retorna status ok e dados doS cursoS </returns>
        [HttpGet("ObterTudo")]
        public IActionResult ObterTudo()
        {
            var cursos = _cursoService.ObterTodosCursos();
            if (cursos == null || cursos.Count() == 0)
            {
                return NotFound("Não foi encontrado curso algum");
            }

            return Ok(cursos);
        }

        /// <summary>
        /// Este serviço permite cadastrar curso para o usuário autenticado.
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [HttpPost]
        public IActionResult Criar(CursoDTO cursoDTO)
        {
            if (string.IsNullOrEmpty(cursoDTO.Nome))
            {
                return BadRequest(new { Erro = "O nome do curso não pode estar vazio!" });
            }
 
            var curso = _cursoService.CriarCurso(cursoDTO);
            
            return CreatedAtAction(nameof(ObterPorId), new { id = curso.Id }, curso);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var cursoBanco = _cursoService.ObterCursoPorId(id);

            if (cursoBanco == null)
            {
                return NotFound();
            }

            _cursoService.DeletarCurso(id);

            return NoContent();
        }
    }
}