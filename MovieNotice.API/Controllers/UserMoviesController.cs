using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMoviesController : ControllerBase
    {
        private readonly IUserMoviesService _userMoviesService;

        public UserMoviesController(IUserMoviesService userMoviesService)
        {
            _userMoviesService = userMoviesService;
        }

        [HttpGet]
        public MoviesListDto GetFollowedMovies()
        {
            return _userMoviesService.GetFollowedMovies(2);
        }

        [HttpPost("createList")]
        public ActionResult CreateNewList([FromBody] MoviesListDto followedMoviesDto)
        {
            _userMoviesService.CreateNewList(followedMoviesDto);
            return Ok(followedMoviesDto);
        }
        [HttpPost("addMovieToList")]
        public ActionResult AddMovieToList([FromBody] MovieToListDto movieToListDto)
        {
            _userMoviesService.AddMovieToList(movieToListDto);
            return Ok();
        }


    }
}
