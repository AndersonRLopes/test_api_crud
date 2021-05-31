using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisApiRestCRUD.Models;
using SisApiRestCRUD.Repositorios.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisApiRestCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        #region Váriaveis da Classe
        private ICategoriaRepositorio _categoriaRepositorio;
        #endregion

        #region Construtor da Classe
        public CategoriasController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }
        #endregion

        ///<summary>
        ///Listar todas as categorias
        ///</summary>      
        [HttpGet]
        [Route("")]
        public IEnumerable<Categoria> ListarCategorias(){

            var categorias = _categoriaRepositorio.ObterTodosCategorias();

            return categorias;
        }

        ///<summary>
        ///Pesquisar Categoria por Código
        ///</summary>   
        [HttpGet("{id}")]
        public IActionResult CategoriaId(int id)
        {
            var categoria =  _categoriaRepositorio.ObterCategoria(id);

            if (categoria == null)
            {
                return NotFound(new { message = "Categoria não encontrado." });
            }

            return Ok(categoria);
        }

        ///<summary>
        ///Cadastrar a Categoria
        ///</summary>   
        [HttpPost]
        [Route("")]
        public ActionResult<Categoria> CadastrarCategoria([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepositorio.Cadastrar(categoria);

                return Ok(new { message = "A Categoria " + categoria.Descricao + " foi cadastrada com sucesso!" });
            }
            else
            {
                return BadRequest(categoria);
            }

        }

        ///<summary>
        ///Atualizar a Categoria
        ///</summary> 
        [HttpPut("{id}")]
        public ActionResult<Categoria> AtualizarCategoria(int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            var categoriaAtual = _categoriaRepositorio.ObterCategoria(id);
            if (categoriaAtual == null)
            {
                return NotFound(new { message = "Categoria não encontrado." });
            }
            else
            {
                categoriaAtual.Descricao = categoria.Descricao;

                _categoriaRepositorio.Atualizar(categoriaAtual);

                return Ok(new { message = "A Categoria " + categoriaAtual.Descricao + " foi alterada com sucesso!" });
            }
        }

        ///<summary>
        ///Deletar a Categoria
        ///</summary> 
        [HttpDelete("{id}")]
        public ActionResult<Categoria> DeletarCategoria(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            var categoriaAtual = _categoriaRepositorio.ObterCategoria(id);
            if (categoriaAtual == null)
            {
                return NotFound(new { message = "Categoria não encontrado." });
            }
            else
            {

                List<Curso> cursos = _categoriaRepositorio.CursosCategorias(categoriaAtual.Codigo);

                if (cursos.Count > 0)
                {
                    return BadRequest(new { message = "Essa categoria não pode ser deletada, pois possui vínculos a outros dados cadastrados!" });
                }

                _categoriaRepositorio.Excluir(categoriaAtual);

                return Ok(new { message = "A Categoria " + categoriaAtual.Descricao + " foi excluída com sucesso!" });
            }
        }
    }
}