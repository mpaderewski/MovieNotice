using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;
using System.Security.Claims;

namespace MovieNotice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoteMoviesController : ControllerBaseAuth
    {
        private readonly IRemoteMoviesService _remoteMovieService;

        private readonly string? userId;

        public RemoteMoviesController(IRemoteMoviesService remoteMovieService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _remoteMovieService = remoteMovieService;
            userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetMovie(int id)
        {
            var movie = await _remoteMovieService.GetMovieAsync(id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("{title}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MovieDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetMovies(string title)
        {
            var movieList = await _remoteMovieService.GetMoviesAsync(title);
            if(movieList == null)
            {
                return NotFound();
            }
            return Ok(movieList);
        }
        

        [HttpGet("Popular")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MovieDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> GetGetMoviePopularList()
        {
            var movieList = await _remoteMovieService.GetMoviesPopularListAsync();
            if(movieList == null)
            {
                return NotFound();
            }

            return Ok(movieList);
        }
        
    }
}
