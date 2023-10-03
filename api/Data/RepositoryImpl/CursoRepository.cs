using api.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data.RepositoryImpl
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

        public void Commit()
        {
            // Salvar mudanças no banco de dados
            _contexto.SaveChanges();
        }

        public IList<Curso> ObterPorUsuario(int idUsuario)
        {
            return _contexto.Cursos.Include(i => i.Usuario).Where(w => w.IdUsuario == idUsuario).ToList();
        }
        
    }
}