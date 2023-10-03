using api.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data.RepositoryImpl
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EscolaContext _context;

        public UsuarioRepository(EscolaContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            // Adicionar curso ao banco de dados
            _context.Cursos.Add(usuario);
        }

        public void Commit()
        {
            // Salvar mudanças no banco de dados
            _contexto.SaveChanges();
        }

         public async Task<Usuario> ObterUsuarioAsync(string nome)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Nome == nome);
        }
    }
}