using Web.Services;

namespace Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _shoppingCartService;
        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        /// <summary>
        /// 原ShoppingCartCheck
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var shoppingCartData = await _shoppingCartService.GetShoppingCartCheckList();
            return View(shoppingCartData);
        }
    }
}
