using ReviewDB.Domain.Entities;

namespace ReviewDB.Infra.Data.Repository.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepositoryAsync<T> GetRepositoryAsync<T>() where T : BaseEntity;
    }
}
