using Web.Entities;
using Web.Services;

namespace Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberDataService _memberDataService;
        private readonly OrderDetailService _orderDetailService;      

        public MemberController(MemberDataService memberDataService,OrderDetailService orderdetailservice)
        {
            _memberDataService = memberDataService;
            _orderDetailService = orderdetailservice;           
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
            int testMemberId = 15;  // 測試使用 MemberId
            var memberProfile = await _memberDataService.GetMemberData(testMemberId);

            return View(memberProfile);
        }
        public async Task<IActionResult> MemberTransaction()
        {

            //for (var x = 0; x < 4; x++)
            //{
            //    var OrderDatail = await _orderService.GetOrderData(x);
            //}
            var Orderdetail = await _orderDetailService.GetOrderData(1);
            return View(Orderdetail);
        }
        public async Task <IActionResult> WatchList(int memberId)
        {
           
            var watchlist = await _memberDataService.GetWatchList(memberId);
            return View(watchlist);
        }
        public IActionResult ChatWindow()
        {
            return View();
        }
    }
}
