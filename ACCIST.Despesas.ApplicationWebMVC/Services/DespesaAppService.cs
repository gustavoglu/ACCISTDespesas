using ACCIST.Despesas.ApplicationWebMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACCIST.Despesas.ApplicationWebMVC.ViewModels;
using AutoMapper;
using ACCIST.Despesas.ApplicationWebMVC.Models;
using ACCIST.Despesas.ApplicationWebMVC.Models.Interfaces;
using ACCIST.Despesas.ApplicationWebMVC.Models.Repository;

namespace ACCIST.Despesas.ApplicationWebMVC.Services
{
    public class DespesaAppService : IDespesaAppService
    {
        private readonly IDespesaRepository _despesaRepository;

        public DespesaAppService()
        {
            this._despesaRepository = new DespesaRepository();
        }

        public DespesaViewModel Ativar(DespesaViewModel despesaViewModel)
        {
            var despesa = _despesaRepository.Ativar(Mapper.Map<Despesa>(despesaViewModel));
            return Mapper.Map<DespesaViewModel>(despesa);
        }

        public DespesaViewModel Atualizar(DespesaViewModel despesaViewModel)
        {
            var despesa = _despesaRepository.Atualizar(Mapper.Map<Despesa>(despesaViewModel));
            return Mapper.Map<DespesaViewModel>(despesa);
        }

        public DespesaViewModel Criar(DespesaViewModel despesaViewModel)
        {
            var despesa = _despesaRepository.Criar(Mapper.Map<Despesa>(despesaViewModel));
            return Mapper.Map<DespesaViewModel>(despesa);
        }

        public void Dispose()
        {
            _despesaRepository.Dispose();
        }

        public DespesaViewModel Inativar(DespesaViewModel despesaViewModel)
        {
            var despesa = _despesaRepository.Inativar(Mapper.Map<Despesa>(despesaViewModel));
            return Mapper.Map<DespesaViewModel>(despesa);
        }

        public DespesaViewModel RetornaPorId(Guid Id)
        {
            return Mapper.Map<DespesaViewModel>(_despesaRepository.RetornaPorId(Id));
        }

        public IEnumerable<DespesaViewModel> RetornarAtivos()
        {
            return Mapper.Map<IEnumerable<DespesaViewModel>>(_despesaRepository.RetornarAtivos());
        }

        public IEnumerable<DespesaViewModel> RetornarInativos()
        {
            return Mapper.Map<IEnumerable<DespesaViewModel>>(_despesaRepository.RetornarInativos());
        }
    }
}