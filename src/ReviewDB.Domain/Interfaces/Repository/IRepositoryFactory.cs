using ReviewDB.Domain.Entities;

namespace ReviewDB.Domain.Interfaces.Repository.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepositoryAsync<T> GetRepositoryAsync<T>() where T : BaseEntity;
    }
}
