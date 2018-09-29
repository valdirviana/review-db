using AutoMapper;
using ReviewDB.Application.Interfaces.MovieAgreggate;
using ReviewDB.Application.ViewModel;
using ReviewDB.Domain.Commands.MovieAgreggate;
using ReviewDB.Domain.Core.Bus;
using ReviewDB.Domain.Entities.MovieAggregate;
using ReviewDB.Domain.Interfaces.Repository.Interfaces;
using ReviewDB.Domain.Interfaces.UoW;
using System.Threading.Tasks;

namespace ReviewDB.Application.Services.MovieAgreggate
{
    public class MovieAppService : IMovieAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryAsync<Movie> _repositoryAsync;
        //private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public MovieAppService(IMapper mapper,
                                  IUnitOfWork unitOfWork,
                                  IMediatorHandler bus
                                  //,IEventStoreRepository eventStoreRepository
                                )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            Bus = bus;
            _repositoryAsync = _unitOfWork.GetRepositoryAsync<Movie>();
            //_eventStoreRepository = eventStoreRepository;
        }

        public async Task<IPaginate<Movie>> GetListAsync()
        {
            var result = await _repositoryAsync.GetListAsync();
            return result;
        }

        public async Task Register(MovieViewModel movieViewModel)
        {
            var registerCommand = _mapper.Map<RegisterMovieCommand>(movieViewModel);
            await Bus.SendCommand(registerCommand);
        }
    }
}
