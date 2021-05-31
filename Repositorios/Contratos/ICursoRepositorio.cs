using SisApiRestCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisApiRestCRUD.Repositorios.Contratos
{
    public interface ICursoRepositorio
    {
        void Cadastrar(Curso curso);

        void Atualizar(Curso curso);

        void Excluir(Curso curso);

        Curso ObterCurso(int Id);

        IEnumerable<Curso> ObterTodosCursos();
    }
}
