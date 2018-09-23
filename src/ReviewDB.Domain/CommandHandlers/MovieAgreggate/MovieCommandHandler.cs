using MediatR;
using ReviewDB.Domain.Commands.MovieAgreggate;
using ReviewDB.Domain.Core.Bus;
using ReviewDB.Domain.Core.Notifications;
using ReviewDB.Domain.Entities.MovieAggregate;
using ReviewDB.Domain.Interfaces.Repository.Interfaces;
using ReviewDB.Domain.Interfaces.UoW;
using System.Threading;
using System.Threading.Tasks;

namespace ReviewDB.Domain.CommandHandlers.MovieAgreggate
{
    public class MovieCommandHandler : 
        CommandHandler,
        IRequestHandler<RegisterMovieCommand>,
        IRequestHandler<UpdateMovieCommand>,
        IRequestHandler<RemoveMovieCommand>
    {
        private readonly IRepositoryAsync<Movie> _movieRepository;
        private readonly IMediatorHandler _bus;

        public MovieCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _movieRepository = uow.GetRepositoryAsync<Movie>();
            _bus = bus;
        }

        public Task<Unit> Handle(RegisterMovieCommand request, CancellationToken cancellationToken)
        {

            return Unit.Task;
        }

        public Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {


            return Unit.Task;
        }

        public Task<Unit> Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
        {

            return Unit.Task;
        }
    }
}
