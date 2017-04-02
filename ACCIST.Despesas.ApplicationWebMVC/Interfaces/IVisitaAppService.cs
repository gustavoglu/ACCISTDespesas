using ACCIST.Despesas.ApplicationWebMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Interfaces
{
    public interface IVisitaAppService : IDisposable
    {
        VisitaViewModel Criar(VisitaViewModel visitaViewModel);
        VisitaViewModel Atualizar(VisitaViewModel visitaViewModel);
        VisitaViewModel RetornaPorId(Guid Id);
        IEnumerable<VisitaViewModel> RetornarAtivos();
        IEnumerable<VisitaViewModel> RetornarInativos();
        VisitaViewModel Inativar(VisitaViewModel visitaViewModel);
        VisitaViewModel Ativar(VisitaViewModel visitaViewModel);
    }
}