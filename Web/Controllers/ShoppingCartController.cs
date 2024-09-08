using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices;
using Web.Entities;

namespace Web.Controllers
{
    //[Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _shoppingCartService;
        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        /// <summary>
        /// ShoppingCart頁面
        /// 設計一個VM接收option回傳的值(asp-for="對應value的VM欄位")
        /// </summary>
        public async Task<IActionResult> Index([FromQuery] int memberId)
        {
            if (!_shoppingCartService.HasMemberData(memberId))
            { return RedirectToAction(nameof(HomeController.Account), "Home"); }
            var cartData = await _shoppingCartService.GetShoppingCartViewModelsAsync(memberId);
            var result = new ShoppingCartListViewModel
            {
                MemberId = memberId,
                ShoppingCartList = cartData
            };
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart([FromForm] int memberId, [FromForm] int courseId, [FromForm] int courseLength, [FromForm] int quantity)
        {
            if (!_shoppingCartService.HasMemberData(memberId))
            { return RedirectToAction(nameof(HomeController.Account), "Home"); }
            if (!_shoppingCartService.HasCourseData(courseId))
            { return RedirectToAction(nameof(HomeController.Index), "Home", new { memberId }); }
            await _shoppingCartService.GetShoppingCartData(memberId, courseId, courseLength, quantity);
            return RedirectToAction(nameof(Index), "ShoppingCart", new { memberId });
        }

        public  IActionResult Delete([FromForm] int memberId, [FromForm] int courseId)
        {


            return RedirectToAction(nameof(Index), "ShoppingCart", new { memberId });
        }
    }
}
