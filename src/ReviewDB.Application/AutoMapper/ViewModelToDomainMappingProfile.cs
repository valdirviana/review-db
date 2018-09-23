using AutoMapper;
using ReviewDB.Application.ViewModel;
using ReviewDB.Domain.Commands.MovieAgreggate;

namespace ReviewDB.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<MovieViewModel, RegisterMovieCommand>()
                .ConstructUsing(c => new RegisterMovieCommand(c.Title));
            CreateMap<MovieViewModel, UpdateMovieCommand>()
                .ConstructUsing(c => new UpdateMovieCommand(c.Id, c.Title));
        }
    }
}