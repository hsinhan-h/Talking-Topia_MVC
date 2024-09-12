using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseService _courseService;
        private readonly MemberDataService _memberDataService;

        public HomeController(ILogger<HomeController> logger, CourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }
        public async Task <IActionResult> Index()
        {
            var course = await _courseService.GetCourseList();
            return View(course);
        }
        public IActionResult Account()
        {
            bool isLoggedIn = User.Identity.IsAuthenticated;
            ViewData["IsLoggedIn"] = isLoggedIn; // 將登入狀態存入 ViewData
            return View();
        }
        // 登入
        [HttpPost]
        //public IActionResult Login(AccountViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // 查詢資料庫中的會員資料
        //        var user = _memberDataService.Members.SingleOrDefault(m => m.Email == model.Email && m.Password == model.Password);

        //        if (user != null)
        //        {
        //            // 將會員資料保存至 Session
        //            HttpContext.Session.SetString("MemberData", JsonConvert.SerializeObject(user));

        //            return RedirectToAction("Index", "Member");
        //        }
        //    }

        //    ModelState.AddModelError("", "登入失敗，請確認帳號或密碼");
        //    return View(model);
        //}
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Questions()
        {
            return View();
        }
    }
}
