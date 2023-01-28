using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Interfaces
{
    public interface IRemoteMoviesService
    {
        public Task<MovieDto> GetMovieAsync(int id);
        public Task<List<MovieDto>> GetMoviesAsync(string title);
        public Task<List<MovieDto>> GetMoviesPopularListAsync();

    }
}
