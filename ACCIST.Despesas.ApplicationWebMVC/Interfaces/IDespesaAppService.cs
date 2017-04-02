using ACCIST.Despesas.ApplicationWebMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Interfaces
{
    public interface IDespesaAppService : IDisposable
    {
        DespesaViewModel Criar(DespesaViewModel despesaViewModel);
        DespesaViewModel Atualizar(DespesaViewModel despesaViewModel);
        DespesaViewModel RetornaPorId(Guid Id);
        IEnumerable<DespesaViewModel> RetornarAtivos();
        IEnumerable<DespesaViewModel> RetornarInativos();
        DespesaViewModel Inativar(DespesaViewModel despesaViewModel);
        DespesaViewModel Ativar(DespesaViewModel despesaViewModel);
    }
}