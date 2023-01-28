using AutoMapper;
using MovieNotice.API.Data;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Services
{
    public class RemoteMoviesService : IRemoteMoviesService
    {
        private readonly IRemoteMovieApi _movieApi;
        private readonly string _language = "pl-PL";
        private readonly IMapper _mapper;

        public RemoteMoviesService(IRemoteMovieApi movieApi, IMapper mapper) 
        {
            _movieApi = movieApi;
            _mapper = mapper;
        }
        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieApi.GetClient().GetMovieAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<List<MovieDto>> GetMoviesAsync(string title)
        {
            var movies = await _movieApi.GetClient().SearchMovieAsync(title, language: _language);
            var moviesDtoList = _mapper.Map<List<MovieDto>>(movies.Results.OrderByDescending(x => x.Popularity).ToList());
            return moviesDtoList;
        }

        public async Task<List<MovieDto>> GetMoviesPopularListAsync()
        {
            var movies = await _movieApi.GetClient().GetMoviePopularListAsync(language: _language);
            var moviesDtoList = _mapper.Map<List<MovieDto>>(movies.Results.ToList());
            return moviesDtoList;
        }
    }
}
