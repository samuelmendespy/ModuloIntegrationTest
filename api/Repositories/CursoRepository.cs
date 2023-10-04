using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly EscolaContext _context;

        public CursoRepository(EscolaContext context)
        {
            _context = context;
        }

        public void Adicionar(Curso curso)
        {
            // Adicionar curso ao banco de dados
            _context.Cursos.Add(curso);
        }

        public void Remover(Curso curso)
        {
            _context.Cursos.Remove(curso);
        }

        public void Commit()
        {
            // Salvar mudanças no banco de dados
            _context.SaveChanges();
        }

        public Curso? ObterPorId(int idCurso){
            return _context.Cursos.Find(idCurso);
        }

        public IList<Curso>? ObterPorUsuario(int idUsuario)
        {
            return _context.Cursos.Include(i => i.Usuario).Where(w => w.IdUsuario == idUsuario).ToList();
        }

        public List<Curso> ObterTodosOsCursos()
        {
            return _context.Cursos.ToList();
        }
        
    }
}