using api.DTOs;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario CriarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Nome = usuarioDTO.Nome,
                Telefone = usuarioDTO.Telefone,
                Ativo = usuarioDTO.Ativo,
            };

            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();

            return usuario;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.Atualizar(usuario);
            _usuarioRepository.Commit();

        }

        public void DeletarUsuario(int id)
        {
            var usuario = _usuarioRepository.ObterPorId(id);
            if (usuario != null)
            {
                try{
                _usuarioRepository.Remover(usuario);
                _usuarioRepository.Commit();
                }
                catch{
                }
            }
            
        }

        public Usuario? ObterUsuarioPorId(int id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public List<Usuario>? ObterUsuarioPorNome(string nome)
        {
            return _usuarioRepository.ObterPorNome(nome);
        }

        public List<Usuario>? ObterTodosUsuarios()
        {
            return _usuarioRepository.ObterTodosOsUsuarios();
        }
    }
}