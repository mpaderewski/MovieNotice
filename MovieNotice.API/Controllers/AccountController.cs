using Microsoft.AspNetCore.Mvc;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

//using System.Text.Json;

namespace MovieNotice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService) 
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUserAsync([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUserAsync(dto);
            return Ok();
        }

        [HttpPost("login")]
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
