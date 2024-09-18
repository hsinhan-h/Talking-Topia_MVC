using ApplicationCore.Entities;
using Web.Entities;
using Web.Services;

namespace Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberDataService _memberDataService;
        private readonly OrderDetailService _orderDetailService;
        private readonly MemberAppointmentService _memberAppointmentService;

        public MemberController(MemberDataService memberDataService,OrderDetailService orderdetailservice, MemberAppointmentService memberappointmentService)
        {
            _memberDataService = memberDataService;
            _orderDetailService = orderdetailservice;
            _memberAppointmentService = memberappointmentService;
        }
        /// <summary>
        /// 原MemberCenterHomepage.cshtml頁面
        /// 調整為學員課程預約明細
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var memberId = 15; // 測試使用 MemberId
            var viewModel = await _memberAppointmentService.GetAppointmentData(memberId);

            // 確保 viewModel 被正確初始化
            if (viewModel == null)
            {
                viewModel = new MemberAppointmentViewModel
                {
                    MemberAppointmentList = new List<MemberAppointmentVM>() // 初始化為空列表
                };
            }
            else if (viewModel.MemberAppointmentList == null)
            {
                viewModel.MemberAppointmentList = new List<MemberAppointmentVM>(); // 確保列表不為 null
            }

            return View(viewModel); // 將正確初始化的 viewModel 傳遞到視圖
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
        public async Task <IActionResult> WatchList()
        {
            ///var WatchListViewModel = await _watchListService.GetWatchList();
            return View();
        }
        public IActionResult ChatWindow()
        {
            return View();
        }
    }
}
