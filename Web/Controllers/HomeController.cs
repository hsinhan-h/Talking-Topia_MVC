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
            ViewData["IsLoggedIn"] = isLoggedIn; // �N�n�J���A�s�J ViewData
            return View();
        }

        // �n�J
        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _repository.GetAll<Member>()
                    .SingleOrDefaultAsync(m => m.Email == model.Email && m.Password == model.Password);

                if (user != null)
                {
                    // �N�|����ƫO�s�� Session
                    HttpContext.Session.SetString("MemberData", JsonConvert.SerializeObject(user));

                    return RedirectToAction("Index", "Member");
                }
                else
                {
                    ModelState.AddModelError("", "�n�J���ѡA�нT�{�b���αK�X");
                }
            }

            return View(model);
        }


        //���U
        [HttpPost]
        public async Task<IActionResult> Register(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountService.RegisterUserAsync(model);

                    // ���U���\��A�^����
                    return RedirectToAction("Index", "Home");
                }
                catch (UserAlreadyExistsException)
                {
                    ModelState.AddModelError("", "�ӹq�l�l��w�Q���U");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "���U�L�{���o�Ϳ��~");
                    ModelState.AddModelError("", "���U�L�{���o�Ϳ��~�A�еy��A�աC");
                }
            }

            // �p�G ModelState �L�ĩΥX�{���~�A��^ Account ����ܿ��~�T��
            return View("Account", model);
        }
        public IActionResult Logout()
        {
            // �M�� Session ���
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
