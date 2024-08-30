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

        //public async Task<IActionResult> ShoppingCartCheck()
        //{
        //}
    }
}
