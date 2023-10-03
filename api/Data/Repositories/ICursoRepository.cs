using api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        void Commit();

        IList<Curso> ObterPorUsuario(int idUsuario);
    }
}