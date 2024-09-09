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
            ViewData["IsLoggedIn"] = isLoggedIn; // �N�n�J���A�s�J ViewData
            return View();
        }
        // �n�J
        [HttpPost]
        //public IActionResult Login(AccountViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // �d�߸�Ʈw�����|�����
        //        var user = _memberDataService.Members.SingleOrDefault(m => m.Email == model.Email && m.Password == model.Password);

        //        if (user != null)
        //        {
        //            // �N�|����ƫO�s�� Session
        //            HttpContext.Session.SetString("MemberData", JsonConvert.SerializeObject(user));

        //            return RedirectToAction("Index", "Member");
        //        }
        //    }

        //    ModelState.AddModelError("", "�n�J���ѡA�нT�{�b���αK�X");
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
