using api.Data;
using api.Models;
using api.Repositories;
using api.DTOs;

namespace api.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository  = cursoRepository;
        }

        public Curso? ObterCursoPorId(int id)
        {
            return _cursoRepository.ObterPorId(id);
        }

        public List<Curso> ObterTodosCursos()
        {
            return _cursoRepository.ObterTodosOsCursos();
        }

        public Curso CriarCurso(CursoDTO cursoDTO)
        {
            var curso = new Curso
            {
                Nome = cursoDTO.Nome,
                Descricao = cursoDTO.Descricao,
                Ofertado = cursoDTO.Ofertado,
                IdUsuario = cursoDTO.IdUsuario,
            };

            _cursoRepository.Adicionar(curso);
            _cursoRepository.Commit();

            return curso;
        }

        public void DeletarCurso(int id)
        {
            var curso = _cursoRepository.ObterPorId(id);

            if (curso != null)
            {
                _cursoRepository.Remover(curso);
                _cursoRepository.Commit();
            }
        }

        
    }
}