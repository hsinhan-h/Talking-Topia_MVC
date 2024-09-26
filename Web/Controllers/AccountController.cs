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
using TalkingTopiaContext = Infrastructure.Data.TalkingTopiaDbContext;
using ApplicationCore.Interfaces;


namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly TalkingTopiaContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly AccountService _accountService;
        private readonly IRepository _repository;
        private readonly ILineAuthService _lineAuthService;


        public AccountController(TalkingTopiaContext context, ILogger<AccountController> logger, AccountService accountService, IRepository repository, ILineAuthService lineAuthService)
        {
            _context = context;
            _logger = logger;
            _accountService = accountService;
            _repository = repository;
            _lineAuthService = lineAuthService;
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
        [HttpGet]
        public IActionResult Register()
        {
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

                    // 註冊成功後，使用 TempData 傳遞成功訊息
                    TempData["SuccessMessage"] = "註冊成功，請重新登入";
                    return RedirectToAction("RegisterSuccess");

                }
                catch (UserAlreadyExistsException)
                {
                    // 添加錯誤訊息到 ModelState
                    ModelState.AddModelError(nameof(model.RegisterViewModel.Email), "該電子郵件已被註冊");

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
                                                 //Console.WriteLine($"帳號:{request.Email}");
                                                 //Console.WriteLine($"密碼:{request.Password}");

            // 首先檢查 ModelState 是否有效
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is not valid");
                ModelState.AddModelError(string.Empty, "登入失敗，請檢查您的輸入資料");
                return View("AccessDenied", model); // 返回登入頁面，顯示錯誤
            }

            // 檢查 Email 和 Password 是否為空
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                ModelState.AddModelError(string.Empty, "帳號或密碼不可為空");
                Console.WriteLine("空空空空空空空空空空");
                return View("AccessDenied", model); // 返回登入頁面並顯示錯誤訊息
            }

            // 使用 AccountService 驗證用戶
            var user = await _accountService.ValidateUserAsync(request.Email, request.Password);

            // 驗證用戶是否存在
            if (user == null)
            {
                // 如果用戶不存在或密碼不正確，添加錯誤訊息到 ModelState
                ModelState.AddModelError(string.Empty, "無效的帳號或密碼");
                Console.WriteLine("無效的帳號或密碼");
                return View("AccessDenied", model); // 返回登入頁面，顯示錯誤訊息
            }

            //取得使用者角色
            //var userRoles = _context.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
            //var userRoleClaims = _context.Roles.Where(x => userRoles.Contains(x.Id)).ToList().Select(role => new Claim(ClaimTypes.Role, role.Name));

            // 登入成功，設定 Cookie.
            var claims = new List<Claim>
            {
                // 儲存 Email 到 HttpContext.User.Identity.Name
                new Claim(ClaimTypes.Name, user.FirstName),
            
                // 將會員的 MemberId 儲存到 NameIdentifier，方便後續提取
                new Claim(ClaimTypes.NameIdentifier, user.MemberId.ToString()) // 修正 'user.Id' 為 'user.MemberId'
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

        public IActionResult RegisterSuccess()
        {
            if (TempData["SuccessMessage"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult LineLogin()
        {
            var state = Guid.NewGuid().ToString("N");
            HttpContext.Session.SetString("LineState", state);

            var redirectUrl = $"https://access.line.me/oauth2/v2.1/authorize?response_type=code&client_id=2006372467&redirect_uri=https://localhost:7263/Account/SSOcallback&state={state}&scope=profile%20openid%20email";
            return Redirect(redirectUrl);
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> SSOcallback(string code, string state)
        {
            var accessToken = await _lineAuthService.GetAccessTokenAsync(code);
            var userProfile = await _lineAuthService.GetUserProfileAsync(accessToken);

            // 檢查 LineUserId 是否有效
            if (string.IsNullOrEmpty(userProfile.LineUserId))
            {
                throw new Exception("無法取得 LineUserId，登入失敗");
            }

            // 使用 LineUserId 查找 Members 表中的用戶
            var existingMember = await _repository.GetMemberByLineIdAsync(userProfile.LineUserId);

            if (existingMember == null)
            {
                // 處理 email 為空的情況
                var email = string.IsNullOrEmpty(userProfile.Email) ? $"{userProfile.LineUserId}@line.com" : userProfile.Email;

                // 新增 User 到 Users 表
                var newUser = new User
                {
                    Name = userProfile.DisplayName,
                    Email = email,
                    LineId = userProfile.LineUserId,
                    PictureUrl = userProfile.PictureUrl
                };

                _repository.Create(newUser);
                await _repository.SaveChangesAsync();

                // 新增 Member 到 Members 表
                var newMember = new Member
                {
                    UserId = newUser.Id, // 將 User Id 設定到 Member 中
                    LineUserId = userProfile.LineUserId,
                    FirstName = userProfile.DisplayName,
                    Password = GenerateRandomPassword(),
                    LastName = "", // 預設為空白
                    Birthday = null,
                    Email = userProfile.Email ?? $"{userProfile.LineUserId}@line.com", // 使用者可能沒有 email
                    Nickname = "",
                    Phone = "",
                    HeadShotImage = userProfile.PictureUrl,
                    Cdate = DateTime.Now,
                    Udate = DateTime.Now,
                    IsTutor = false,
                    IsVerifiedTutor = false,
                };

                _repository.Create(newMember);
                await _repository.SaveChangesAsync();

                existingMember = newMember;
            }



            // 設置登入 Claims，確保使用 Members 表中的 MemberId
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, existingMember.MemberId.ToString()),
        new Claim(ClaimTypes.Name, existingMember.FirstName),
        new Claim("picture", existingMember.HeadShotImage ?? string.Empty)
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

            return RedirectToAction("Index", "Home");
        }

        private string GenerateRandomPassword(int length = 10)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(validChars, length).Select(s => s[random.Next(s.Length)]).ToArray());
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
