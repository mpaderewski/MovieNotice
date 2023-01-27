using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Interfaces
{
    public interface IRemoteMoviesService
    {
        public Task<MovieDto> GetAsync(int id);
        public Task<List<MovieDto>> GetAsync(string title);
        public Task<List<MovieDto>> GetMoviePopularListAsync();

    }
}
