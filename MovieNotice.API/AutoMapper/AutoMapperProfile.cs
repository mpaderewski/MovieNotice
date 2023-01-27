using AutoMapper;
using MovieNotice.API.Entities;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MoviesList, MoviesListDto>();
            CreateMap<Movie, MovieToListDto>();

            CreateMap<TMDbLib.Objects.Movies.Movie, MovieDto>()
                .ForMember(dest => dest.PosterUrl, opt => opt.MapFrom(src => src.PosterPath))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Overview));

            CreateMap<TMDbLib.Objects.Search.SearchMovie, MovieDto>()
                .ForMember(dest => dest.PosterUrl, opt => opt.MapFrom(src => src.PosterPath))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Overview));
        }
    }
}
