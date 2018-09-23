using AutoMapper;
using ReviewDB.Application.ViewModel;
using ReviewDB.Domain.Entities.MovieAggregate;

namespace ReviewDB.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Movie, MovieViewModel>();
        }
    }
}
