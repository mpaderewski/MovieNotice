using MovieNotice.API.Data;
using MovieNotice.API.Helpers.Extensions;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.Models;

namespace MovieNotice.API.Services
{
    public class RemoteMoviesService : IRemoteMoviesService
    {
        private readonly IRemoteMovieApi _movieApi;
        private readonly string _language = "pl-PL";

        public RemoteMoviesService(IRemoteMovieApi movieApi) 
        {
            _movieApi = movieApi;
        }
        public async Task<Movie> GetAsync(int id)
        {
            var movie = await _movieApi.GetClient().GetMovieAsync(id);
            return movie.ConvertToCommonMovie();
        }

        public async Task<List<Movie>> GetAsync(string title)
        {
            var movies = await _movieApi.GetClient().SearchMovieAsync(title, language: _language);
            return movies.ConvertToCommonMovieICollection().OrderByDescending(x => x.Popularity).ThenByDescending(a => a.ReleaseDate).ToList();
        } 
    }
}
