using ACCIST.Despesas.ApplicationWebMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACCIST.Despesas.ApplicationWebMVC.ViewModels;
using ACCIST.Despesas.ApplicationWebMVC.Models.Interfaces;
using ACCIST.Despesas.ApplicationWebMVC.Models.Repository;
using AutoMapper;
using ACCIST.Despesas.ApplicationWebMVC.Models;

namespace ACCIST.Despesas.ApplicationWebMVC.Services
{
    public class Despesa_AnexoAppService : IDespesa_AnexoAppService
    {
        private readonly IDespesa_AnexoRepository _despesa_AnexoRepository;

        public Despesa_AnexoAppService()
        {
            _despesa_AnexoRepository = new Despesa_AnexoRepository();
        }

        public Despesa_AnexoViewModel Ativar(Despesa_AnexoViewModel despesa_AnexoViewModel)
        {
            var despesaanexo = this._despesa_AnexoRepository.Ativar(Mapper.Map<Despesa_Anexo>(despesa_AnexoViewModel));
            return Mapper.Map<Despesa_AnexoViewModel>(despesaanexo);
        }

        public Despesa_AnexoViewModel Atualizar(Despesa_AnexoViewModel despesa_AnexoViewModel)
        {
            var despesaanexo = this._despesa_AnexoRepository.Atualizar(Mapper.Map<Despesa_Anexo>(despesa_AnexoViewModel));
            return Mapper.Map<Despesa_AnexoViewModel>(despesaanexo);
        }

        public Despesa_AnexoViewModel Criar(Despesa_AnexoViewModel despesa_AnexoViewModel)
        {
            var despesaanexo = this._despesa_AnexoRepository.Criar(Mapper.Map<Despesa_Anexo>(despesa_AnexoViewModel));
            return Mapper.Map<Despesa_AnexoViewModel>(despesaanexo);
        }

        public void Dispose()
        {
            _despesa_AnexoRepository.Dispose();
        }

        public Despesa_AnexoViewModel Inativar(Despesa_AnexoViewModel despesa_AnexoViewModel)
        {
            var despesaanexo = this._despesa_AnexoRepository.Inativar(Mapper.Map<Despesa_Anexo>(despesa_AnexoViewModel));
            return Mapper.Map<Despesa_AnexoViewModel>(despesaanexo);
        }

        public Despesa_AnexoViewModel RetornaPorId(Guid Id)
        {
            return Mapper.Map<Despesa_AnexoViewModel>( _despesa_AnexoRepository.RetornaPorId(Id));
        }

        public IEnumerable<Despesa_AnexoViewModel> RetornarAtivos()
        {
            return Mapper.Map<IEnumerable<Despesa_AnexoViewModel>>(_despesa_AnexoRepository.RetornarAtivos());
        }

        public IEnumerable<Despesa_AnexoViewModel> RetornarInativos()
        {
            return Mapper.Map<IEnumerable<Despesa_AnexoViewModel>>(_despesa_AnexoRepository.RetornarInativos());
        }
    }
}