using Microsoft.AspNetCore.Mvc;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBaseAuth
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userService = userService;
        }

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetUser() 
        {
            var userId = GetUserId();
            var user = _userService.GetUser(userId);
            
            if(user == null) 
            {
                return NotFound();
            }

            return Ok(_userService.GetUser(userId));

        }
    }
}
