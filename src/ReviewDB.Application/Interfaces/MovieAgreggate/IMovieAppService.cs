using ReviewDB.Domain.Entities.MovieAggregate;
using ReviewDB.Domain.Interfaces.Repository.Interfaces;
using System.Threading.Tasks;

namespace ReviewDB.Application.Interfaces.MovieAgreggate
{
    public interface IMovieAppService
    {
        Task<IPaginate<Movie>> GetListAsync();
    }
}
