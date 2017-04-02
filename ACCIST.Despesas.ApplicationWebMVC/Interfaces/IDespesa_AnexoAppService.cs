using ACCIST.Despesas.ApplicationWebMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Interfaces
{
    public interface IDespesa_AnexoAppService : IDisposable
    {
        Despesa_AnexoViewModel Criar(Despesa_AnexoViewModel despesa_AnexoViewModel);
        Despesa_AnexoViewModel Atualizar(Despesa_AnexoViewModel despesa_AnexoViewModel);
        Despesa_AnexoViewModel RetornaPorId(Guid Id);
        IEnumerable<Despesa_AnexoViewModel> RetornarAtivos();
        IEnumerable<Despesa_AnexoViewModel> RetornarInativos();
        Despesa_AnexoViewModel Inativar(Despesa_AnexoViewModel despesa_AnexoViewModel);
        Despesa_AnexoViewModel Ativar(Despesa_AnexoViewModel despesa_AnexoViewModel);
    }
}