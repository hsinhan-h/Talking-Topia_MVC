using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices;
using Web.Entities;

namespace Web.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
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
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int memberId, [FromQuery] int courseId, [FromQuery] int courseLength, [FromQuery] int quantity)
        {
            //todo: 新增課程至購物車(Create)
            var cartData = await _shoppingCartService.GetShoppingCartData(memberId, courseId, courseLength, quantity);
            return View(cartData);

        }
        [HttpPost]
        public async Task<IActionResult> GetCart([FromQuery] int memberId, [FromQuery] int courseId, [FromQuery] int courseLength, [FromQuery] int quantity)
        {
            //todo: 確認ShoppingCart是否有資料(Read)
            var cartData = await _shoppingCartService.GetShoppingCartData(memberId, courseId, courseLength, quantity);
            return View("Index");

        }
    }
}
