using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisApiRestCRUD.Models
{
    public class Categoria
    {
        //PK
        [Key]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo ''Descrição'' é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

    }
}
