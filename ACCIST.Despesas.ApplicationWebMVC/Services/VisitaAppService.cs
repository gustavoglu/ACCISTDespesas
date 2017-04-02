using ACCIST.Despesas.ApplicationWebMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACCIST.Despesas.ApplicationWebMVC.ViewModels;
using ACCIST.Despesas.ApplicationWebMVC.Models.Interfaces;
using ACCIST.Despesas.ApplicationWebMVC.Models.Repository;
using ACCIST.Despesas.ApplicationWebMVC.Models;
using AutoMapper;

namespace ACCIST.Despesas.ApplicationWebMVC.Services
{
    public class VisitaAppService : IVisitaAppService
    {
        private readonly IVisitaRepository _visitaRepository;

        public VisitaAppService()
        {
            _visitaRepository = new VisitaRepository();
        }

        public VisitaViewModel Ativar(VisitaViewModel visitaViewModel)
        {
            var visita = _visitaRepository.Ativar(Mapper.Map<Visita>(visitaViewModel));
            return Mapper.Map<VisitaViewModel>(visita);
        }

        public VisitaViewModel Atualizar(VisitaViewModel visitaViewModel)
        {
            var visita = _visitaRepository.Atualizar(Mapper.Map<Visita>(visitaViewModel));
            return Mapper.Map<VisitaViewModel>(visita);
        }

        public VisitaViewModel Criar(VisitaViewModel visitaViewModel)
        {

            var visita = _visitaRepository.Criar(Mapper.Map<Visita>(visitaViewModel));
            return Mapper.Map<VisitaViewModel>(visita);
        }

        public void Dispose()
        {
            this._visitaRepository.Dispose();

        }

        public VisitaViewModel Inativar(VisitaViewModel visitaViewModel)
        {
            var visita = _visitaRepository.Inativar(Mapper.Map<Visita>(visitaViewModel));
            return Mapper.Map<VisitaViewModel>(visita);
        }

        public VisitaViewModel RetornaPorId(Guid Id)
        {
            return Mapper.Map<VisitaViewModel>(_visitaRepository.RetornaPorId(Id));
        }

        public IEnumerable<VisitaViewModel> RetornarAtivos()
        {
            return Mapper.Map<IEnumerable<VisitaViewModel>>(_visitaRepository.RetornarAtivos());
        }

        public IEnumerable<VisitaViewModel> RetornarInativos()
        {
            return Mapper.Map<IEnumerable<VisitaViewModel>>(_visitaRepository.RetornarInativos());
        }
    }
}