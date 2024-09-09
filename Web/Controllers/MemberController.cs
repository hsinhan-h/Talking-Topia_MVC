using Web.Entities;
using Web.Services;

namespace Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberDataService _memberDataService;

        public MemberController(MemberDataService memberDataService)
        {
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
        public async Task<IActionResult> MemberData(int memberId)
        {
            //var summaryData = await _memberDataService.GetMemberData(memberId);  // 使用 MemberId 查找
            //return View(summaryData);
            int testMemberId = 2;  // 測試使用 MemberId = 2
            var memberProfile = await _memberDataService.GetMemberData(testMemberId);

            return View(memberProfile);
        }
        public async Task<IActionResult> MemberTransaction()
        {
            //var orderManagementListViewModel = await _orderService.GetOrderList();
            return View();
        }
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
