using Microsoft.EntityFrameworkCore;
using ReviewDB.Domain.Entities;
using ReviewDB.Infra.Data.Repository.Interfaces;
using System;

namespace ReviewDB.Infra.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
