using api.Models;

namespace api.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Remover(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Commit();
        Usuario? ObterPorId(int idUsuario);
        List<Usuario>? ObterPorNome(string nome);
        List<Usuario>? ObterTodosOsUsuarios();
        Task<Usuario>? ObterUsuarioAsync(string nome);
    }
}