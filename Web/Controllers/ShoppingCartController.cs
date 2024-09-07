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
        /// Course頁面應回傳時長(value設定為25或50)與堂數(value設定堂數)
        /// 設計一個VM接收option回傳的值(asp-for="對應value的VM欄位")
        /// </summary>
        public async Task<IActionResult> Index([FromQuery] int memberId)
        {
            var cartData = await _shoppingCartService.GetShoppingCartViewModelsAsync(memberId);
            var result = new ShoppingCartListViewModel
            {
                ShoppingCartList = cartData
            };
            return View(result);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart([FromForm] int memberId, [FromForm] int courseId, [FromForm] int courseLength, [FromForm] int quantity)
        {
            var cartData = await _shoppingCartService.GetShoppingCartData(memberId, courseId, courseLength, quantity);
            return RedirectToAction(nameof(Index), new { MemberId = memberId });
        }
    }
}
