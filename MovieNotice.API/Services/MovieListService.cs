using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieNotice.API.Entities;
using MovieNotice.API.Helpers.Extensions;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Services
{
    public class MovieListService : IMovieListService
    {
        private readonly MovieNoticeDbContext _context;
        private readonly IMapper _mapper;

        public MovieListService(MovieNoticeDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        
        public MoviesListDto? GetList(int listId)
        {
            var list = _context.MoviesList.Include(x => x.Movies).FirstOrDefault(x => x.Id == listId);
            return _mapper.Map<MoviesListDto>(list);
        }

        public List<MoviesListDto>? GetLists(int userId)
        {
            var lists = _context.MoviesList.Include(x => x.Movies).Where(x => x.UserId == userId).ToList();
            return _mapper.Map<List<MoviesListDto>>(lists);
        }
        
        
        public void AddMovie(MovieToListDto movieToListDto)
        {
            var list = _context.MoviesList.FirstOrDefault(x => x.Id == movieToListDto.ListId);
            
            var movie = _mapper.Map<Movie>(movieToListDto);

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

        public void Create(MoviesListDto moviesListDto) 
        {
            var moviesList = _mapper.Map<MovieList>(moviesListDto);
            _context.MoviesList.Add(moviesList);
            _context.SaveChanges();
        }
    }
}
