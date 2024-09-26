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
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            if (!result) { return BadRequest("找不到會員"); }

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

            // 嘗試將會員ID轉換為整數
            if (!int.TryParse(memberIdClaim.Value, out int parsedMemberId))
            {
                return Content($"無效的會員 ID: {memberIdClaim.Value}"); // 顯示取得的值進行檢查
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
            // 從使用者 Claims 中取得 memberIdClaim
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

             // 如果沒有找到會員 ID 的 Claim，重定向到登入頁面
            if (memberIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // 嘗試將 memberIdClaim.Value 轉換為整數
            if (!int.TryParse(memberIdClaim.Value, out int memberId))
            {
                return BadRequest("無效的會員 ID");
            }

            // 根據 memberId 取得訂單明細
            var orderDetail = await _orderDetailService.GetOrderData(memberId);

            // 確認訂單明細是否為空
            if (orderDetail == null)
            {
                return NotFound("找不到訂單明細");
            }

            return View(orderDetail);
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
