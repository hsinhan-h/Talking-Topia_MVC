using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]  // 只有持有有效 JWT 的使用者才能訪問
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardApiService _dashboardApiService;

        public DashboardController(DashboardApiService dashboardApiService)
        {
            _dashboardApiService = dashboardApiService;
        }

        [HttpGet]
        public IActionResult GetDashboard()
        {
            return Ok(new { message = "Welcome to the protected dashboard!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            var result = await _dashboardApiService.GetAllData();

            return Ok(new BaseApiResponse(result));
        }
    }
}
