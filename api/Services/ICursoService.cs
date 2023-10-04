using api.Models;
using api.DTOs;
using System.Collections.Generic;

namespace api.Services
{
    public interface ICursoService
    {
        Curso? ObterCursoPorId(int id);
        List<Curso> ObterTodosCursos();
        Curso CriarCurso(CursoDTO cursoDTO);
        void DeletarCurso(int id);
    }
}