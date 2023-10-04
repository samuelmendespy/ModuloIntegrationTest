using api.Models;

namespace api.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        void Remover(Curso curso);
        void Commit();
        Curso? ObterPorId(int idCurso);

        // Obter uma lista de cursos associados a um usuário
        IList<Curso>? ObterPorUsuario(int idUsuario);
        List<Curso> ObterTodosOsCursos();

    }
}