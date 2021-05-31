using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SisApiRestCRUD.Data;
using SisApiRestCRUD.Models;
using SisApiRestCRUD.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisApiRestCRUD.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        DataContext _banco;
        private IConfiguration _conf;

        public CategoriaRepositorio(DataContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }

        public void Atualizar(Categoria categoria)
        {
            _banco.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Add(categoria);
            _banco.SaveChanges();
        }

        public List<Curso> CursosCategorias(int id)
        {
            return _banco.Cursos.Include(ca => ca.Categoria).Where(cr => cr.CategoriaId == id).ToList();
        }

        public void Excluir(Categoria categoria)
        {
            _banco.Remove(categoria);
            _banco.SaveChanges();
        }

        public Categoria ObterCategoria(int Id)
        {
            return _banco.Categorias.Find(Id);
        }

        public IEnumerable<Categoria> ObterTodosCategorias()
        {
            return _banco.Categorias.ToList();
        }
    }
}
