using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
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
            // Adicionar usuario ao banco de dados
            _context.Usuarios.Add(usuario);
        }

        public void Remover(Usuario usuario)
        {
            // Remover usuario do banco de dados
            _context.Usuarios.Remove(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }
        public void Commit()
        {
            // Salvar mudanças no banco de dados
            _context.SaveChanges();
        }

         public List<Usuario>? ObterTodosOsUsuarios()
        {
            return _context.Usuarios.ToList();
        }
        
        public Usuario? ObterPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }
        public List<Usuario>? ObterPorNome(string nome)
        {
            return _context.Usuarios.Where(x => x.Nome.Equals(nome)).ToList();
        }

         public async Task<Usuario>? ObterUsuarioAsync(string nome)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Nome.Equals(nome));
            if (usuario == null)
            {
                usuario = new Usuario();
                usuario.Nome = "Usuario não encontrado";
                return usuario;
            }

            return usuario;
        }

       
        
    }
}