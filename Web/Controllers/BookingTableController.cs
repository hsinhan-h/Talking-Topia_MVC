using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BookingTableController : Controller
    {
        private readonly BookingService _bookingService;
        public BookingTableController(BookingService bookingService, CourseService courseService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int CourseId, DateTime BookingDate, int BookingTime)
        {

            // todo: 剩餘堂數 > 0, 允許預約
            // 寫入booking資料表, 導向預約成功頁面
            //MemberId先暫時用1帶入
            int remainSessions = await _bookingService.GetRemainCourseQtyAsync(1, CourseId);
            if (remainSessions > 0)
            {
                _bookingService.CreateBookingData(CourseId, BookingDate, BookingTime, 1);
                return RedirectToAction("Success", "BookingTable");
            }

            //todo: 剩餘堂數 <= 0, 跳轉購物車, 將課程寫入購物車資料表

            return RedirectToAction("Success", "BookingTable");

        }


        public IActionResult Success()
        {
            return View();
        }
    }

    
}
