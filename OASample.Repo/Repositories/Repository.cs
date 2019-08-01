using Microsoft.EntityFrameworkCore;
using OASample.Data;
using OASample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OASample.Repo.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(DbContext ctx)
        {
            this.context = ctx ?? throw new ArgumentNullException(nameof(context));
            this.dbSet = this.context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;

            this.dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }            
            entity.ModifiedDate = DateTime.Now;
            this.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.AsEnumerable<T>();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.ModifiedDate = DateTime.Now;

            this.dbSet.Update(entity);
        }
    }
}
