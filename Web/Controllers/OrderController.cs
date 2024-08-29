using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var shoppingCartInfoListViewModel = await _orderService.GetShoppingCartInfoList();
            return View(shoppingCartInfoListViewModel);
        }
    }
}
