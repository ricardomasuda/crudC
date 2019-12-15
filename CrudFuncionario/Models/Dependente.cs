using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudFuncionario.Models
{
    public class Dependente
    {
        [Display(Name ="Id")]
        public int DependenteId { get; set; }
        [Display(AutoGenerateField =false)]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }
    }
}