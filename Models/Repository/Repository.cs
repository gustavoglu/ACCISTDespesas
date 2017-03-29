using ACCIST.Despesas.ApplicationWebMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ACCIST.Despesas.ApplicationWebMVC.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext Db;
        protected DbSet<T> DbSet;

        public Repository()
        {
            Db = new ApplicationDbContext();
            DbSet = Db.Set<T>();
        }

        public virtual T Ativar(T obj)
        {
            obj.Ativo = true;

            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            this.SalvarAlteracoes();

            return obj;

        }

        public virtual T Atualizar(T obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            this.SalvarAlteracoes();

            return obj;
        }

        public virtual T Criar(T obj)
        {
            this.DbSet.Add(obj);

            SalvarAlteracoes();

            return obj;
            
        }

        public void Dispose()
        {
            this.Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual T Inativar(T obj)
        {

            obj.Ativo = false;

            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            this.SalvarAlteracoes();

            return obj;
        }

        public virtual IEnumerable<T> Pesquisar(Expression<Func<T, bool>> Expression)
        {
            return DbSet.Where(Expression);
        }

        public virtual T RetornaPorId(Guid Id)
        {
            return DbSet.SingleOrDefault(obj => obj.Id == Id);
        }

        public virtual IEnumerable<T> RetornarAtivos()
        {
            return DbSet.Where(obj => obj.Ativo == true);
        }

        public virtual IEnumerable<T> RetornarInativos()
        {
            return DbSet.Where(obj => obj.Ativo == false);
        }

        int SalvarAlteracoes()
        {
          return this.Db.SaveChanges();
        }
    }
}