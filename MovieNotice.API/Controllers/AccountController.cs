using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

//using System.Text.Json;

namespace MovieNotice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBaseAuth
    {
        private readonly IAccountService _accountService;

        public AccountController(IMapper mapper, IAccountService accountService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
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
