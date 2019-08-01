using Microsoft.EntityFrameworkCore;
using OASample.Data;
using OASample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Repo.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        void Commit();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
