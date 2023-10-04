using api.Models;

namespace api.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        void Remover(Curso curso);
        void Commit();
        Curso? ObterPorId(int idCurso);
        IList<Curso>? ObterPorUsuario(int idUsuario);
        List<Curso> ObterTodosOsCursos();

    }
}