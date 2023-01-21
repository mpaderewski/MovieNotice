using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.Models;

namespace MovieNotice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RemoteMoviesController : ControllerBase
    {
        private readonly IRemoteMoviesService _remoteMovieService;

        public RemoteMoviesController(IRemoteMoviesService remoteMovieService)
        {
            _remoteMovieService = remoteMovieService;
        }

        [HttpGet("{id:int}")]
        public async Task<Movie> GetAsync(int id)
        {
            return await _remoteMovieService.GetAsync(id);
        }

        [HttpGet("{title}")]
        public async Task<List<Movie>> GetAsync(string title)
        {
            return await _remoteMovieService.GetAsync(title);
        }
    }
}
