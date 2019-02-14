using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class EstoqueConsultaViewModel
    {
        public int IdEstoque { get; set; }
        public string Nome { get; set; }
    }
}