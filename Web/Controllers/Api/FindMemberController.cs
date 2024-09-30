using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FindMemberController : ControllerBase
    {
        [HttpGet]
        public IActionResult IsLoggedIn()
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            {
                return Ok(new { isLoggedIn = false });
            }
            var memberId = memberIdClaim.Value;
            return Ok(new { isLoggedIn = true, memberId });
        }
    }
}
