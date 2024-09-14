using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web.Exceptions;
using Web.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseService _courseService;
        private readonly MemberDataService _memberDataService;
        private readonly AccountService _accountService;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger, CourseService courseService, MemberDataService memberDataService, IRepository repository, AccountService accountService)
        {
            _logger = logger;
            _courseService = courseService;
            _memberDataService = memberDataService;
            _repository = repository;
            _accountService = accountService;

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
        public async Task<IActionResult> Login(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _repository.GetAll<Member>()
                    .SingleOrDefaultAsync(m => m.Email == model.Email && m.Password == model.Password);

                if (user != null)
                {
                    // 將會員資料保存至 Session
                    HttpContext.Session.SetString("MemberData", JsonConvert.SerializeObject(user));

                    return RedirectToAction("Index", "Member");
                }
                else
                {
                    ModelState.AddModelError("", "登入失敗，請確認帳號或密碼");
                }
            }

            return View(model);
        }


        //註冊
        [HttpPost]
        public async Task<IActionResult> Register(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountService.RegisterUserAsync(model);

                    // 註冊成功後，回首頁
                    return RedirectToAction("Index", "Home");
                }
                catch (UserAlreadyExistsException)
                {
                    ModelState.AddModelError("", "該電子郵件已被註冊");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "註冊過程中發生錯誤");
                    ModelState.AddModelError("", "註冊過程中發生錯誤，請稍後再試。");
                }
            }

            // 如果 ModelState 無效或出現錯誤，返回 Account 並顯示錯誤訊息
            return View("Account", model);
        }
        public IActionResult Logout()
        {
            // 清除 Session 資料
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
