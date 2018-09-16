using ReviewDB.Domain.Interfaces.UoW;
using ReviewDB.Domain.Services.Interfaces;
using ReviewDB.Domain.Entities.MovieAggregate;

namespace ReviewDB.Domain.Services
{
    public class MovieDomainService : DomainServiceBase<Movie>, IMovieDomainService
    {
        public MovieDomainService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
