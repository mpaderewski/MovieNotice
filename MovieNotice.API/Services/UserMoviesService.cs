using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieNotice.API.Entities;
using MovieNotice.API.Helpers.Extensions;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Services
{
    public class UserMoviesService : IUserMoviesService
    {
        private readonly MovieNoticeDbContext _context;
        private readonly IMapper _mapper;

        public UserMoviesService(MovieNoticeDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        
        public MoviesListDto GetFollowedMovies(int userId)
        {
            var dupa = _context.MoviesList.Include(x => x.Movies).FirstOrDefault(x => x.UserId == userId);
            var followedMoviesDto = _mapper.Map<MoviesListDto>(dupa);
            return followedMoviesDto;
        }
        
        
        public void AddMovieToList(MovieToListDto movieDto)
        {
            var list = _context.MoviesList.FirstOrDefault(x => x.Id == movieDto.ListId);
            
            var movie = _mapper.Map<Movie>(movieDto);

            if (list != null)
            {
                if (list.Movies == null)
                {
                    list.Movies = new List<Movie>();
                }
                list.Movies.AddIfNotExists(movie);
            }

            _context.SaveChanges();
        }

        public void CreateNewList(MoviesListDto followedMoviesDto) 
        {
            var followedMovies = _mapper.Map<MoviesList>(followedMoviesDto);
            _context.MoviesList.Add(followedMovies);
            _context.SaveChanges();
        }
    }
}
