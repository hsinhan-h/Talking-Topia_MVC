using ApplicationCore.Interfaces;
using Infrastructure.ECpay;
using Infrastructure.Interfaces.ECpay;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            if (!result)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            var cartData = await _shoppingCartViewModelService.GetShoppingCartViewModelsAsync(memberId);
            var scVM = new ShoppingCartListViewModel
            {
                ShoppingCartList = cartData
            };
            return View(scVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart([FromForm] int courseId, [FromForm] int courseLength, [FromForm] int quantity)
        {

            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            if (!result)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            if (!_courseService.IsCourse(courseId))
            { return RedirectToAction(nameof(HomeController.Index), "Home", new { memberId }); }
            if (!_shoppingCartService.HasCartItem(memberId, courseId))
            { await _shoppingCartService.CreateShoppingCartAsync(memberId, courseId, courseLength, quantity); }
            await _shoppingCartService.GetAllShoppingCartAsync(memberId);
            return RedirectToAction(nameof(Index), "ShoppingCart", new { memberId });
        }

        public async Task<IActionResult> Delete([FromForm] int courseId)
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            _shoppingCartService.DeleteCartItem(memberId, courseId);
            return RedirectToAction(nameof(Index), "ShoppingCart", new { memberId });
        }

    }
}
