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
        [HttpGet]
        public async Task<IActionResult> Index(int memberId)
        {
            //初次進購物車tempCart為空
            //todo: 先確認ShoppingCart是否有資料
            //todo: 無資料 - create路線 - get/post
            //todo: 有資料 - read路線 - post

            //todo: 
            if (memberId > -1)
            {
                var shoppingCartData = await _shoppingCartService.GetShoppingCartCheckList();
                return View(shoppingCartData);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
