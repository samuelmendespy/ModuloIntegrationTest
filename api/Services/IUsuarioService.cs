using api.Models;
using api.DTOs;


namespace api.Services
{
    public interface IUsuarioService
    {
        Usuario? ObterUsuarioPorId(int id);
        Usuario? ObterUsuarioPorNome(string nome);
        List<Usuario>? ObterTodosUsuarios();
        Usuario CriarUsuario(UsuarioDTO usuarioDTO);
        void DeletarUsuario(int id);
        void AtualizarUsuario(Usuario usuario);
        
    }
}