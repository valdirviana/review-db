using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReviewDB.Domain.Entities;
using ReviewDB.Domain.Interfaces.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ReviewDB.Infra.Data.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public RepositoryAsync(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity) => await AddAsync(entity, new CancellationToken());

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken)) => await _dbSet.AddAsync(entity, cancellationToken);

        public async Task AddAsync(params T[] entities) => await _dbSet.AddRangeAsync(entities);

        public async Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken)) => await _dbSet.AddRangeAsync(entities, cancellationToken);

        public void UpdateAsync(T entity) => _dbSet.Update(entity);

        public async Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int index = 0, int size = 20, bool disableTracking = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToPaginateAsync(index, size, 0, cancellationToken);
            else
                return await query.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking)         
                query = query.AsNoTracking();
            

            if (include != null)
                query = include(query);          

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();
            else
                return await query.FirstOrDefaultAsync();
        }
    }
}
