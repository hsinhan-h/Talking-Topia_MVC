using Web.Services;

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
        /// <summary>
        /// 原MemberCenterHomepage.cshtml頁面
        /// 調整為學員課程預約明細
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> MemberData()
        {
            var summaryData = await _memberDataService.GetMemberData("tommy85");
            return View(summaryData);
        }
        //public async Task<IActionResult> MemberTransaction()
        //{
        //    var orderManagementListViewModel = await _orderService.GetOrderList();
        //    return View(orderManagementListViewModel);
        //}
        public IActionResult WatchList()
        {
            return View();
        }
        public IActionResult ChatWindow()
        {
            return View();
        }
    }
}
