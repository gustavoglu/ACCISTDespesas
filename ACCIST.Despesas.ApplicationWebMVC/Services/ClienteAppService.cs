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
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            this._clienteRepository = new ClienteRepository();
        }
        public ClienteViewModel Ativar(ClienteViewModel clienteViewModel)
        {
            var cliente = this._clienteRepository.Ativar(Mapper.Map<Cliente>(clienteViewModel));
            return Mapper.Map<ClienteViewModel>(cliente);
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = this._clienteRepository.Atualizar(Mapper.Map<Cliente>(clienteViewModel));
            return Mapper.Map<ClienteViewModel>(cliente);
        }

        public ClienteViewModel Criar(ClienteViewModel clienteViewModel)
        {
            var cliente = this._clienteRepository.Criar(Mapper.Map<Cliente>(clienteViewModel));
            return Mapper.Map<ClienteViewModel>(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public ClienteViewModel Inativar(ClienteViewModel clienteViewModel)
        {
            var cliente = this._clienteRepository.Inativar(Mapper.Map<Cliente>(clienteViewModel));
            return Mapper.Map<ClienteViewModel>(cliente);
        }

        public ClienteViewModel RetornaPorId(Guid Id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.RetornaPorId(Id));
        }

        public IEnumerable<ClienteViewModel> RetornarAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.RetornarAtivos());
        }

        public IEnumerable<ClienteViewModel> RetornarInativos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.RetornarAtivos());
        }
    }
}