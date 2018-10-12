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
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.OriginalTitle, opt => opt.MapFrom(src => src.OriginalTitle))
                .ForMember(x => x.TmdbId, opt => opt.MapFrom(src => src.TmdbId))
                .ForMember(x => x.Popularity, opt => opt.MapFrom(src => src.Popularity));

            CreateMap<MovieViewModel, UpdateMovieCommand>()
                .ConstructUsing(c => new UpdateMovieCommand(c.Id, c.OriginalTitle));
        }
    }
}
