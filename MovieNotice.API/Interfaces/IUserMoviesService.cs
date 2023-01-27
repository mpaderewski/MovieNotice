using MovieNotice.API.Entities;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Interfaces
{
    public interface IUserMoviesService
    {
        public MoviesListDto GetFollowedMovies(int followedListId);
        public void AddMovieToList(MovieToListDto movieDto);
        public void CreateNewList(MoviesListDto followedMoviesDto);
    }
}
