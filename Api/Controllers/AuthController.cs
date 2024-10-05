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

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginDto request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                //return BadRequest();
                return Ok(new BaseApiResponse()
                {
                    IsSuccess = false,
                    ErrMsg = "帳號或密碼錯誤!!",
                });
            }

            var jwtResult = _jwtService.GenerateToken(request.Username, 1);
            //var result = new BaseApiResponse()
            //{
            //    IsSuccess = true,
            //    Body = jwtResult,
            //    ErrMsg = "",

            //};

            // 有寫建構式就可以用以下寫法(有寫一個有參數的建構式記得要補一個無參數建構式給類別)
            var result = new BaseApiResponse(jwtResult);

            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUserName()
        {
            var userName = User.Identity?.Name;

            if (userName is null)
            {
                return Ok(new BaseApiResponse
                {
                    ErrMsg = "無法取得UserName",
                });
            }
            //var result = new BaseApiResponse()
            //{
            //    IsSuccess = true,
            //    Body = userName,
            //    ErrMsg = string.Empty,
            //};

            var result = new BaseApiResponse(userName);

            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult GetClaims()
        {
            return Ok(new BaseApiResponse(User.Claims.Select(x => new { x.Type, x.Value })));
        }

    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
