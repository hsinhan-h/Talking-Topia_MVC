using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RoleController : Controller
    {
        // 會員功能（任何已登入的使用者）
        [Authorize]
        public IActionResult MemberFeature() =>
        Content("會員功能");

        // 教師專屬功能
        [Authorize(Roles = "Tutor")]
        public IActionResult TutorFeature() =>
        Content("教師專屬功能");

        // 系統管理員功能
        [Authorize(Roles = "Admin")]
        public IActionResult AdminFeature() =>
        Content("系統管理員功能");
    }
}
