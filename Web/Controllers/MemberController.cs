using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Web.Entities;

namespace Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberDataService _memberDataService;
        private readonly OrderDetailService _orderDetailService;
        private readonly IRepository _repository;


        public MemberController(MemberDataService memberDataService,OrderDetailService orderdetailservice, IRepository repository)
        {
            _memberDataService = memberDataService;
            _orderDetailService = orderdetailservice;
            _repository = repository;

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
        // 接收 AJAX 發送的資料來更新會員資料
        [HttpPost]
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
