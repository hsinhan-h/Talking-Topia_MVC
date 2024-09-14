using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
            int testMemberId = 1;  // 測試使用 MemberId
            var memberProfile = await _memberDataService.GetMemberData(testMemberId);

            return View(memberProfile);
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

        //[HttpGet]
        //public async Task<IActionResult> EditMemberData(int memberId)
        //{
        //    var memberProfile = await _memberDataService.GetMemberData(memberId);
        //    return View(memberProfile);  // 傳遞會員資料
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditMemberData(MemberProfileViewModel memberProfile, int memberId)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // 傳遞 memberProfile 和 memberId
        //            await _memberDataService.UpdateMemberData(memberProfile, memberId);
        //            return RedirectToAction("MemberData", new { memberId });
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", ex.Message);
        //        }
        //    }
        //    return View(memberProfile);
        //}

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
