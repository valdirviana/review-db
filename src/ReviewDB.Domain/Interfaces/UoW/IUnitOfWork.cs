using Microsoft.EntityFrameworkCore;
using ReviewDB.Domain.Entities;
using ReviewDB.Domain.Interfaces.Repository.Interfaces;
using System;

namespace ReviewDB.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : BaseEntity;

        bool Commit();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
