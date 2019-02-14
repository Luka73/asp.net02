using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class EstoqueCadastroViewModel
    {
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe um nome.")]
        public string Nome { get; set; }
    }
}