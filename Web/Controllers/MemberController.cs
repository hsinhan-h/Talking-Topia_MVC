using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Web.Entities;
using Web.Services;

namespace Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberDataService _memberDataService;
        private readonly OrderDetailService _orderDetailService;   
        private readonly IMemberService _memberService;
        private readonly MemberAppointmentService _memberAppointmentService;

        public MemberController(MemberDataService memberDataService,OrderDetailService orderdetailservice, IMemberService memberService, MemberAppointmentService memberappointmentService)
        {
            _memberDataService = memberDataService;            
            _memberService = memberService;
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

            // 從登入的使用者的 Claims 中提取會員 ID
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            // 如果沒有找到會員 ID 的 Claim，重定向到登入頁面
            if (memberIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // 將會員ID轉換為整數
            int parsedMemberId = int.Parse(memberIdClaim.Value);

            // 驗證會員ID是否有效
            if (parsedMemberId <= 0)
            {
                return BadRequest("無效的會員 ID");
            }

            // 從資料庫中查詢會員資料
            var summaryData = await _memberDataService.GetMemberData(parsedMemberId);


            // 如果沒有找到會員資料
            if (summaryData == null)
            {
                return NotFound("找不到會員資料");
            }

            return View(summaryData);
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
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            
            int memberId = int.Parse(memberIdClaim.Value);

            var watchlist = await _memberDataService.GetWatchList(memberId);
            return View(watchlist);
        }
        public IActionResult ChatWindow()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveProfile([FromBody] MemberProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // 從 Claims 中獲取會員 ID
                    var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                    if (memberIdClaim == null)
                    {
                        return Json(new { success = false, message = "無法取得會員ID，請重新登入" });
                    }

                    int memberId = int.Parse(memberIdClaim.Value);

                    // 使用 Service 層更新會員資料
                    await _memberDataService.UpdateMemberData(model, memberId);

                    return Json(new { success = true, message = "儲存成功" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"儲存失敗: {ex.Message}" });
                }
            }

            return Json(new { success = false, message = "資料驗證失敗" });
        }

    }
}
