using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;
using System.Security.Claims;

namespace MovieNotice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieListController : ControllerBase
    {
        private readonly IMovieListService _userMoviesService;

        public MovieListController(IMovieListService userMoviesService)
        {
            _userMoviesService = userMoviesService;
        }



        [HttpGet("{listId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MoviesListDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetList(int listId)
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
        public ActionResult GetLists()
        {
            var list = _userMoviesService.GetLists(2);
            if (list == null)
            {
                return NoContent();
            }
            return Ok(list);
        }

        [HttpPost("create")]
        public ActionResult CreateNewList([FromBody] MoviesListDto followedMoviesDto)
        {
            _userMoviesService.Create(followedMoviesDto);
            return Ok(followedMoviesDto);
        }
        [HttpPost("addMovie")]
        public ActionResult AddMovie([FromBody] MovieToListDto movieToListDto)
        {
            _userMoviesService.AddMovie(movieToListDto);
            return Ok();
        }
    }
}
