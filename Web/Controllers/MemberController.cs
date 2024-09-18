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

        public MemberController(MemberDataService memberDataService,OrderDetailService orderdetailservice,IMemberService memberService)
        {
            _memberDataService = memberDataService;
            _orderDetailService = orderdetailservice;    
            _memberService = memberService;
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
        [HttpPost]
        public async Task<IActionResult> UpdateMemberData(MemberProfileViewModel memberProfile, int memberId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _memberDataService.UpdateMemberData(memberProfile, memberId);
                    return RedirectToAction("MemberData", new { memberId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
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
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            
            int memberId = int.Parse(memberIdClaim.Value);

            var watchlist = await _memberDataService.GetWatchList(memberId);
            return View(watchlist);
        }
        public IActionResult ChatWindow()
        {
            return View();
        }
    }
}
