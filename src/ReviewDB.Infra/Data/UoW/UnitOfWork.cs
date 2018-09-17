using Microsoft.EntityFrameworkCore;
using ReviewDB.Domain.Entities;
using ReviewDB.Domain.Interfaces.Repository.Interfaces;
using ReviewDB.Domain.Interfaces.UoW;
using ReviewDB.Infra.Data.Repository;
using System;
using System.Collections.Generic;

namespace ReviewDB.Infra.Data.UoW
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork
        where TContext : DbContext
    {
        public TContext Context { get; }
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new RepositoryAsync<TEntity>(Context);
            return (IRepositoryAsync<TEntity>)_repositories[type];
        }

        public bool Commit()
        {
            return Context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
