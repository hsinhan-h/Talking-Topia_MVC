using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using Web.Exceptions;
using Web.Services;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Data;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using System.Security.Cryptography;
using System.Text;
using Web.Data;
using TalkingTopiaContext = Infrastructure.Data.TalkingTopiaContext;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly TalkingTopiaContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly AccountService _accountService;
        private readonly IRepository _repository;

        public AccountController(TalkingTopiaContext context, ILogger<AccountController> logger, AccountService accountService, IRepository repository)
        {
            _context = context;
            _logger = logger;
            _accountService = accountService;
            _repository = repository;
        }
        public IActionResult Index()
        {
            var model = new AccountViewModel
            {
                LoginViewModel = new LoginViewModel(),
                RegisterViewModel = new RegisterViewModel(),
                IsAuthenticated = User.Identity.IsAuthenticated // 判斷是否登入
            };
            return View(model);
        }

        // 帳戶頁面
        public IActionResult Account()
        {
            bool isLoggedIn = User.Identity.IsAuthenticated;
            ViewData["IsLoggedIn"] = isLoggedIn;
            return View();
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

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(loginViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login([FromForm] AccountViewModel model)
        {
            var request = model.LoginViewModel;  // 提取 LoginViewModel
            Console.WriteLine($"帳號:{request.Email}");
            Console.WriteLine($"密碼:{request.Password}");

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            //if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            //{
            //    ModelState.AddModelError(string.Empty, "帳號或密碼不可為空");
            //    return View(request);
            //}

            //驗證帳號密碼
            //var user = _context.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password.ToSHA256());
            //if (user == null)
            //{
            //    ModelState.AddModelError(string.Empty, "帳號或密碼錯誤");
            //    return View(request);
            //}

            //取得使用者角色
            //var userRoles = _context.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
            //var userRoleClaims = _context.Roles.Where(x => userRoles.Contains(x.Id)).ToList().Select(role => new Claim(ClaimTypes.Role, role.Name));

            // 登入成功，設定 Cookie.
            var claims = new List<Claim>
            {
            // 解析Cookie後 會存入 HttpContext.User.Identity.Name 屬性內
            new Claim(ClaimTypes.Name, request.Email),

            //以下角色為角色授權的範例使用，可以自行定義
            //new Claim(ClaimTypes.Role, "Admin"),
            //new Claim(ClaimTypes.Role, "Tutor")

            };

            //加入角色
            //claims.AddRange(userRoleClaims);

            //可以設定 Cookie 的其他屬性 (https://learn.microsoft.com/zh-tw/dotnet/api/microsoft.aspnetcore.authentication.authenticationproperties)
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                IsPersistent = true,
            };

            // 建立 ClaimsIdentity.
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // 建立 ClaimsPrincipal.
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // 網站登入.(寫入cookie, response 回傳後生效)
            await HttpContext.SignInAsync(
                              CookieAuthenticationDefaults.AuthenticationScheme,
                              claimsPrincipal,
                              authProperties);

            //導向處理
            if (string.IsNullOrEmpty(request.ReturnUrl))
            {
                request.ReturnUrl = "/";
            }

            return Redirect(request.ReturnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }

    public static class StringExtensions
    {
        public static string ToSHA256(this string value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
