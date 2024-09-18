using ApplicationCore.Interfaces;
using System.Security.Claims;
using Web.Services;

namespace Web.Controllers
{
    //[Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMemberService _memberService;
        private readonly ICourseService _courseService;
        private readonly ShoppingCartViewModelService _shoppingCartViewModelService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IMemberService memberService, ICourseService courseService, ShoppingCartViewModelService shoppingCartViewModelService)
        {
            _shoppingCartService = shoppingCartService;
            _memberService = memberService;
            _courseService = courseService;
            _shoppingCartViewModelService = shoppingCartViewModelService;
        }
        /// <summary>
        /// ShoppingCart頁面
        /// </summary>
        public async Task<IActionResult> Index()
        {
            //var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            //var temp = memberIdClaim.Subject.Claims;
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            int parsedMemberId = int.Parse(memberIdClaim.Value);
            var memberId = await _memberService.GetMemberId(parsedMemberId);

            if (!_memberService.IsMember(memberId))
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            var cartData = await _shoppingCartViewModelService.GetShoppingCartViewModelsAsync(memberId);
            var result = new ShoppingCartListViewModel
            {
                MemberId = memberId,
                ShoppingCartList = cartData
            };
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddToCart([FromForm] int memberId, [FromForm] int courseId, [FromForm] int courseLength, [FromForm] int quantity)
        public async Task<IActionResult> AddToCart([FromForm] int courseId, [FromForm] int courseLength, [FromForm] int quantity)
        {
            
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            int parsedMemberId = int.Parse(memberIdClaim.Value);
            var memberId = await _memberService.GetMemberId(parsedMemberId);

            if (!_memberService.IsMember(memberId))
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            if (!_courseService.IsCourse(courseId))
            { return RedirectToAction(nameof(HomeController.Index), "Home", new { memberId }); }
            if (!_shoppingCartService.HasCartItem(memberId, courseId))
            { memberId = await _shoppingCartService.CreateShoppingCartAsync(memberId, courseId, courseLength, quantity); }
            await _shoppingCartService.GetAllShoppingCartAsync(memberId);
            return RedirectToAction(nameof(Index), "ShoppingCart", new { memberId });
        }

        public async Task<IActionResult> Delete([FromForm] int memberId, [FromForm] int courseId)
        //public async Task<IActionResult> Delete([FromForm] int courseId)
        {
            var user = HttpContext.User.Identity.Name;
            //var memberId = await _memberService.GetMemberId(user);
            _shoppingCartService.DeleteCartItem(memberId, courseId);
            return RedirectToAction(nameof(Index), "ShoppingCart", new { memberId });
        }
    }
}
