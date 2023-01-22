using MovieNotice.Common.Models;

namespace MovieNotice.API.Interfaces
{
    public interface IRemoteMoviesService
    {
        public Task<Movie> GetAsync(int id);
        public Task<List<Movie>> GetAsync(string title);
        public Task<List<Movie>> GetMoviePopularListAsync();

    }
}
