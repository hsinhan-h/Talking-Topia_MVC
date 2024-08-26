namespace Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly OrderService _orderService;
        private readonly MemberDataService _memberDataService;
        public MemberController(OrderService orderService, MemberDataService memberDataService)
        {
            _orderService = orderService;
            _memberDataService = memberDataService;
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
        public async Task<IActionResult> MemberData()
        {
            var summaryData = await _memberDataService.GetFilteredMemberDataAsync();
            return View(summaryData);
        }
        public async Task<IActionResult> MemberTransaction()
        {
            var orderManagementListViewModel = await _orderService.GetOrderList();
            return View(orderManagementListViewModel);
        }
    }
}
