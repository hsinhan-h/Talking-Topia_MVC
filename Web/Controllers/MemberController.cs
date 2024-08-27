using Web.Services;

namespace Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly OrderService _orderService;
        private readonly MemberDataService _memberDataService;
        private readonly ResumeDataService _resumeDataService;
        public MemberController(OrderService orderService, MemberDataService memberDataService, ResumeDataService resumeDataService)
        {
            _orderService = orderService;
            _memberDataService = memberDataService;
            _resumeDataService = resumeDataService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Toteacher()
        {
            return View();
        }
        public async Task<IActionResult> Toteacher_resume()
        {
            var ResumeSummaryData = await _resumeDataService.GetresumeData();
            return View(ResumeSummaryData);
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
            var summaryData = await _memberDataService.GetMemberData("tommy85");
            return View(summaryData);
        }
        public async Task<IActionResult> MemberTransaction()
        {
            var orderManagementListViewModel = await _orderService.GetOrderList();
            return View(orderManagementListViewModel);
        }
    }
}
