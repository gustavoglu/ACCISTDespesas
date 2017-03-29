using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        T Criar(T obj);

        T Atualizar(T obj);

        T RetornaPorId(Guid Id);

        IEnumerable<T> RetornarAtivos();

        IEnumerable<T> RetornarInativos();

        IEnumerable<T> Pesquisar(Expression<Func<T, bool>> Expression);

        T Inativar(T Id);

        T Ativar(T Id);

    }
}