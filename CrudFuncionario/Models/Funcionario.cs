using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudFuncionario.Models
{
    public class Funcionario
    {
        [Display(Name ="Id")]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Idade")]
        public UInt32 Idade { get; set; }
    }
}