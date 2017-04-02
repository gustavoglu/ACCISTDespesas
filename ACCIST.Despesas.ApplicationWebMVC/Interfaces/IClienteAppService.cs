using ACCIST.Despesas.ApplicationWebMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteViewModel Criar(ClienteViewModel obj);

        ClienteViewModel Atualizar(ClienteViewModel obj);

        ClienteViewModel RetornaPorId(Guid Id);

        IEnumerable<ClienteViewModel> RetornarAtivos();

        IEnumerable<ClienteViewModel> RetornarInativos();

        ClienteViewModel Inativar(ClienteViewModel Id);

        ClienteViewModel Ativar(ClienteViewModel Id);
    }
}