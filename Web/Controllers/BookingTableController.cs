using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Entities;

namespace Web.Controllers
{
    public class BookingTableController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly CourseService _courseService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMemberService _memberService;
        public BookingTableController(BookingService bookingService, CourseService courseService, IShoppingCartService shoppingCartService, IMemberService memberService)
        {
            _bookingService = bookingService;
            _courseService = courseService;
            _shoppingCartService = shoppingCartService;
            _memberService = memberService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int courseId, DateTime bookingDate, short bookingTime)
        {
           
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            if (!result) { return BadRequest("找不到會員"); }

            // todo: 剩餘堂數 > 0, 允許預約
            // 寫入booking資料表, 導向預約成功頁面
            int remainSessions = await _bookingService.GetRemainCourseQtyAsync(memberId, courseId);
            if (remainSessions > 0)
            {
                _bookingService.CreateBookingData(courseId, bookingDate, bookingTime, memberId);
                return RedirectToAction("Success", "BookingTable");
            }

            //todo: 剩餘堂數 <= 0, 將課程寫入購物車資料表, 跳轉購物車 
            else
            {
                //decimal price = _courseService.GetCourse25MinUnitPrice(courseId);
                await _shoppingCartService.CreateShoppingCartAsync(memberId, courseId, 25, 1, bookingDate, bookingTime);
                return RedirectToAction("Index", "ShoppingCart");
            }

        }


        public IActionResult Success()
        {
            return View();
        }
    }


}
