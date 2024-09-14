using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web.Exceptions;
using Web.Services;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly AccountService _accountService;
        private readonly IRepository _repository;

        public AccountController(ILogger<AccountController> logger, AccountService accountService, IRepository repository)
        {
            _logger = logger;
            _accountService = accountService;
            _repository = repository;
        }

        // 帳戶頁面
        public IActionResult Account()
        {
            bool isLoggedIn = User.Identity.IsAuthenticated;
            ViewData["IsLoggedIn"] = isLoggedIn;
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

        // 註冊
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

            return View("Account", model);
        }

        // 登出
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
