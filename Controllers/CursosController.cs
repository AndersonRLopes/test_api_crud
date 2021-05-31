using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisApiRestCRUD.Models;
using SisApiRestCRUD.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisApiRestCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        #region Váriaveis da Classe
        private ICursoRepositorio _cursoRepositorio;
        private ICategoriaRepositorio _categoriaRepositorio;
        #endregion

        #region Construtor da Classe
        public CursosController(ICursoRepositorio cursoRepositorio, ICategoriaRepositorio categoriaRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
        }
        #endregion

        ///<summary>
        ///Listar todas as Cursos
        ///</summary>      
        [HttpGet]
        [Route("")]
        public IEnumerable<Curso> ListarCursos()
        {

            var cursos = _cursoRepositorio.ObterTodosCursos();

            return cursos;
        }

        ///<summary>
        ///Pesquisar o Curso por Código
        ///</summary>     
        [HttpGet("{id}")]
        public IActionResult CursoId(int id)
        {
            var curso = _cursoRepositorio.ObterCurso(id);

            if (curso == null)
            {
                return NotFound(new { message = "Curso não encontrado." });
            }

            return Ok(curso);
        }

        ///<summary>
        ///Cadastrar o Curso
        ///</summary>    
        [HttpPost]
        [Route("")]
        public ActionResult<Curso> CadastrarCurso([FromBody] Curso curso)
        {
            if (ModelState.IsValid)
            {
                if (curso.DataInicio.Date < DateTime.Now.Date )
                {
                    return BadRequest(new { message = "Não é permitida a inclusão de cursos com a data de início menor que a data atual." });
                }
                else if (curso.DataInicio.Date > curso.DataTermino.Date)
                {
                    return BadRequest(new { message = "A data ínicial do curso não pode ser posterior que a data de término." });
                }
                else
                {
                    IEnumerable<Curso> cursos = _cursoRepositorio.ObterTodosCursos();

                    foreach (var item in cursos)
                    {
                        if (
                                (curso.DataInicio.Date <= item.DataInicio.Date && curso.DataTermino.Date >= item.DataInicio.Date)
                            ||  (curso.DataInicio.Date <= item.DataTermino.Date && curso.DataTermino.Date >= item.DataInicio.Date)
                            )
                        {
                            return BadRequest(new { message = "Existe(m) curso(s) planejados(s) dentro do período informado." });
                        }

                    }
                }

                Categoria categoria = _categoriaRepositorio.ObterCategoria(curso.CategoriaId);

                if (categoria == null)
                {
                    return BadRequest(new { message = "A categoria informanda no cadastro do curso não existe!." });
                }

                _cursoRepositorio.Cadastrar(curso);

                return Ok(new { message = "A Curso " + curso.DescricaoAssunto + " foi cadastrada com sucesso!" });
            }
            else
            {
                return BadRequest(curso);
            }

        }

        ///<summary>
        ///Atualizar o Curso
        ///</summary>   
        [HttpPut("{id}")]
        public ActionResult<Curso> AtualizarCurso(int id, [FromBody] Curso curso)
        {
            IEnumerable<Curso> cursos = _cursoRepositorio.ObterTodosCursos();

            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            var cursoAtual = _cursoRepositorio.ObterCurso(id);
            if (cursoAtual == null)
            {
                return NotFound(new { message = "Curso não encontrado." });
            }
            else
            {
                cursoAtual.DescricaoAssunto = curso.DescricaoAssunto;
                cursoAtual.CategoriaId = curso.CategoriaId;
                cursoAtual.QuantidadeAlunosTurma = curso.QuantidadeAlunosTurma;
                cursoAtual.DataInicio = curso.DataInicio;
                cursoAtual.DataTermino = curso.DataTermino;
                    

                if (cursoAtual.DataInicio.Date < DateTime.Now.Date)
                {
                    return BadRequest(new { message = "Não é permitida a inclusão de cursos com a data de início menor que a data atual." });
                }
                else if (cursoAtual.DataInicio.Date > cursoAtual.DataTermino.Date)
                {
                    return BadRequest(new { message = "A data ínicial do curso não pode ser posterior que a data de término." });
                }
                else
                {
                    foreach (var item in cursos)
                    {
                        if (item.Codigo != cursoAtual.Codigo)
                        {
                            if (
                                    (cursoAtual.DataInicio.Date <= item.DataInicio.Date && cursoAtual.DataTermino.Date >= item.DataInicio.Date)
                                || (cursoAtual.DataInicio.Date <= item.DataTermino.Date && cursoAtual.DataTermino.Date >= item.DataInicio.Date)
                            )
                            {
                                return BadRequest(new { message = "Existe(m) curso(s) planejados(s) dentro do período informado." });
                            }
                        }
                    }
                }

                Categoria categoria = _categoriaRepositorio.ObterCategoria(curso.CategoriaId);

                if (categoria == null)
                {
                    return BadRequest(new { message = "A categoria informanda no cadastro do curso não existe!." });
                }

                _cursoRepositorio.Atualizar(cursoAtual);

                return Ok(new { message = "A Curso " + cursoAtual.DescricaoAssunto + " foi alterada com sucesso!" });
            }
        }


        ///<summary>
        ///Deletar o Curso
        ///</summary>   
        [HttpDelete("{id}")]
        public ActionResult<Curso> DeletarCurso(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            var cursoAtual = _cursoRepositorio.ObterCurso(id);
            if (cursoAtual == null)
            {
                return NotFound(new { message = "Curso não encontrado." });
            }
            else
            {
                _cursoRepositorio.Excluir(cursoAtual);

                return Ok(new { message = "A Curso " + cursoAtual.DescricaoAssunto + " foi excluída com sucesso!" });
            }
        }
    }
}
