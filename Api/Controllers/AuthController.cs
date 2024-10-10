using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        // 登入 API，允許匿名訪問
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginDto request)
        {
            // 檢查帳號或密碼是否為空
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return Ok(new BaseApiResponse()
                {
                    IsSuccess = false,
                    ErrMsg = "帳號或密碼錯誤!!",
                });
            }

            // TODO: 這裡應該驗證使用者帳號與密碼是否正確，例如從資料庫比對
            // 假設驗證通過
            if (request.Username == "testuser@gmail.com" && request.Password == "password123")
            {
                // 生成 JWT Token，並設定 30 分鐘有效期
                var jwtResult = _jwtService.GenerateToken(request.Username, 30);
                var result = new BaseApiResponse(jwtResult);

                return Ok(result); // 返回成功結果與 Token
            }

            // 登入失敗，帳號或密碼不正確
            return Ok(new BaseApiResponse()
            {
                IsSuccess = false,
                ErrMsg = "帳號或密碼錯誤!!",
            });
        }

        // 取得目前登入使用者的名稱
        [HttpGet]
        [Authorize]
        public IActionResult GetUserName()
        {
            // 取得 User.Identity.Name (即 JWT "sub" 聲明)
            var userName = User.Identity?.Name;

            if (userName is null)
            {
                return Ok(new BaseApiResponse
                {
                    IsSuccess = false,
                    ErrMsg = "無法取得使用者名稱"
                });
            }

            // 返回使用者名稱
            var result = new BaseApiResponse(userName);
            return Ok(result);
        }

        // 取得當前登入使用者的 Claims
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]  // 限制角色為 SuperAdmin
        public IActionResult GetClaims()
        {
            // 返回當前使用者的所有 Claims
            return Ok(new BaseApiResponse(User.Claims.Select(x => new { x.Type, x.Value })));
        }
    }

    // 登入請求物件
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // 基礎 API 回應物件
    public class BaseApiResponse
    {
        public bool IsSuccess { get; set; } = true;
        public object Body { get; set; }
        public string ErrMsg { get; set; }

        // 無參數建構子
        public BaseApiResponse() { }

        // 只有 Body 的成功建構子
        public BaseApiResponse(object body)
        {
            Body = body;
            IsSuccess = true;
        }
    }
}
