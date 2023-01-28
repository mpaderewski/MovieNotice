using MovieNotice.API.Entities;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Interfaces
{
    public interface IMovieListService
    {
        public MoviesListDto? GetList(int followedListId);
        public List<MoviesListDto>? GetLists(int userId);
        public void AddMovie(MovieToListDto movieDto);
        public void Create(MoviesListDto followedMoviesDto);
    }
}
