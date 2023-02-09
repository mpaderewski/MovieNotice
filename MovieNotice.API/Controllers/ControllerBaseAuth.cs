using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieNotice.API.Controllers
{
    [Authorize]
    public class ControllerBaseAuth : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ControllerBaseAuth(IHttpContextAccessor httpContextAccessor) : base()
        {
            _httpContextAccessor= httpContextAccessor;
        }

        protected int GetUserId()
        {
            if (this._httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value is String)
            {
                return Int32.Parse(this._httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }

            return -1;
        }
    }
}
