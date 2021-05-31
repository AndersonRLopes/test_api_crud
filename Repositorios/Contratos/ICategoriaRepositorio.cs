using SisApiRestCRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisApiRestCRUD.Repositorios.Contratos
{
    public interface ICategoriaRepositorio
    {
        void Cadastrar(Categoria categoria);

        void Atualizar(Categoria categoria);

        void Excluir(Categoria categoria);

        Categoria ObterCategoria(int Id);

        IEnumerable<Categoria> ObterTodosCategorias();

        List<Curso> CursosCategorias(int id);

    }
}
