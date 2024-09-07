using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private readonly ShoppingCartService _shoppingCartService;

        public OrderController(OrderService orderService, ShoppingCartService shoppingCartService)
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
        }

        /// <summary>
        /// 原ShoppingCartInfo.cshtml頁面
        /// Index應傳入金流API回應的參數
        /// 串金流前先直接從ShoppingCart串過來
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var shoppingCartInfoList = await _orderService.GetShoppingCartInfoAsync();
            return View(shoppingCartInfoList);
        }
    }
}
