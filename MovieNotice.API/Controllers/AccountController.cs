using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IMapper mapper, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            var tokenResult = _accountService.GenerateJwt(dto);
            if(tokenResult != null) 
            {
                return Ok(tokenResult);
            }
            return Unauthorized();
        }
    }
}
