using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisApiRestCRUD.Models
{
    public class Curso
    {
        //PK
        [Key]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo ''Descrição do assunto'' é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Descrição do assunto")]
        public string DescricaoAssunto { get; set; }

        [Required(ErrorMessage = "O campo ''Data de início'' é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Data de início")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo ''Data de término'' é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Data de término")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataTermino { get; set; }

        [Display(Name = "Quantidade de alunos por turma")]
        public int? QuantidadeAlunosTurma { get; set; }

        [Required(ErrorMessage = "O campo ''Categoria'' é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
    }
}
