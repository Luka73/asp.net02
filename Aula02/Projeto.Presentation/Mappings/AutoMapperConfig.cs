using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Entities;
using Projeto.Presentation.Models;
using AutoMapper;

namespace Projeto.Presentation.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<EstoqueCadastroViewModel, Estoque>();

            CreateMap<Estoque, EstoqueConsultaViewModel>();
        }
    }
}