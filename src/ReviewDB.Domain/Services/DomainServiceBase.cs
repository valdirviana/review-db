using ReviewDB.Domain.Entities;
using ReviewDB.Domain.Interfaces.Repository.Interfaces;
using ReviewDB.Domain.Interfaces.UoW;

namespace ReviewDB.Domain.Services
{
    public class DomainServiceBase<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public DomainServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IRepositoryAsync<T> GetRepositoryAsync()
        {
            return _unitOfWork.GetRepositoryAsync<T>();
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : BaseEntity
        {
            return _unitOfWork.GetRepositoryAsync<TEntity>();
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
