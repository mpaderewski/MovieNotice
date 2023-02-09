using Microsoft.AspNetCore.Mvc;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieListController : ControllerBaseAuth
    {
        private readonly IMovieListService _userMoviesService;

        public MovieListController(IMovieListService userMoviesService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userMoviesService = userMoviesService;
        }

        [HttpGet("{listId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MoviesListDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetList(int listId)
        {
            var list = _userMoviesService.GetList(listId);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MoviesListDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetLists()
        {
            var list = _userMoviesService.GetLists(GetUserId());
            if (list == null || list.Count == 0)
            {
                return NoContent();
            }
            return Ok(list);
        }

        [HttpPost("create")]
        public IActionResult CreateNewList([FromBody] MoviesListDto followedMoviesDto)
        {
            _userMoviesService.Create(followedMoviesDto);
            return Ok(followedMoviesDto);
        }
        [HttpPost("addMovie")]
        public IActionResult AddMovie([FromBody] MovieToListDto movieToListDto)
        {
            _userMoviesService.AddMovie(movieToListDto);
            return Ok();
        }
    }
}
