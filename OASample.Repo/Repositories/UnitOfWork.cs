using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OASample.Data;
using OASample.Data.Entity;

namespace OASample.Repo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        private Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationContext context)
        {
            this.Context = context;
        }

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (this._repositories == null)
            {
                this._repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!this._repositories.ContainsKey(type)) this._repositories.Add(type, new Repository<TEntity>(this.Context));

            return (IRepository<TEntity>)this._repositories[type];
        }
    }
}
