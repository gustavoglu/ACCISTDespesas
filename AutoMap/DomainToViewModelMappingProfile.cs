using ACCIST.Despesas.ApplicationWebMVC.Models;
using ACCIST.Despesas.ApplicationWebMVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.AutoMap
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            this.CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            this.CreateMap<Visita, VisitaViewModel>().ReverseMap();
            this.CreateMap<Despesa, DespesaViewModel>().ReverseMap();
        }


    }
}