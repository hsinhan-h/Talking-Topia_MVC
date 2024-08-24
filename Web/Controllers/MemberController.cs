namespace Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly OrderService _orderService;
        public MemberController(OrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Toteacher()
        {
            return View();
        }
        public IActionResult Toteacher_resume()
        {
            return View();
        }
        public IActionResult Recommended_teachers_AI()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Chat_window()
        {
            return View();
        }
        public IActionResult MemberCenterHomePage()
        {
            return View();
        }
        public IActionResult MemberData()
        {
            return View();
        }
        public async Task<IActionResult> MemberTransaction()
        {
            var orderManagementListViewModel = await _orderService.GetOrderList();
            return View(orderManagementListViewModel);
        }
    }
}
