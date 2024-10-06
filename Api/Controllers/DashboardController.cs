using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]  // 只有持有有效 JWT 的使用者才能訪問
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDashboard()
        {
            return Ok(new { message = "Welcome to the protected dashboard!" });
        }
    }
}
