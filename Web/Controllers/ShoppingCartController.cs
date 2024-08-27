using Web.Services;

namespace Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly OrderService _orderService;
        public ShoppingCartController(OrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShoppingCartInfo()
        {
            var ShoppingCartInfoListViewModel = await _orderService.GetShoppingCartInfoList();
            return View(ShoppingCartInfoListViewModel); 
        }

        public async Task<IActionResult> ShoppingCartCheck()
        {
            var ShoppingCartCheckListViewModel = await _orderService.GetShoppingCartCheckList();
            return View(ShoppingCartCheckListViewModel);
        }
    }
}
