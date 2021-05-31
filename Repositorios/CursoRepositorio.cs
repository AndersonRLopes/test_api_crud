using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SisApiRestCRUD.Data;
using SisApiRestCRUD.Models;
using SisApiRestCRUD.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisApiRestCRUD.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        DataContext _banco;
        private IConfiguration _conf;

        public CursoRepositorio(DataContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }

        public void Atualizar(Curso curso)
        {
            _banco.Update(curso);
            _banco.SaveChanges();
        }

        public void Cadastrar(Curso curso)
        {
            _banco.Add(curso);
            _banco.SaveChanges();
        }

        public void Excluir(Curso curso)
        {
            _banco.Remove(curso);
            _banco.SaveChanges();
        }

        public Curso ObterCurso(int Id)
        {
            return _banco.Cursos.Include(c => c.Categoria).FirstOrDefault(x => x.Codigo == Id);
        }

        public IEnumerable<Curso> ObterTodosCursos()
        {
            return _banco.Cursos.Include(c => c.Categoria).ToList();
        }
    }
}
