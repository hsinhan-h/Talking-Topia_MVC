using Microsoft.AspNetCore.Mvc;
using Web.Entities;

namespace Web.Controllers
{
    public class BookingTableController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly CourseService _courseService;
        private readonly ShoppingCartService _shoppingCartService;
        public BookingTableController(BookingService bookingService, CourseService courseService, ShoppingCartService shoppingCartService)
        {
            _bookingService = bookingService;
            _courseService = courseService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int CourseId, DateTime BookingDate, short BookingTime)
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

            //todo: 剩餘堂數 <= 0, 將課程寫入購物車資料表, 跳轉購物車 
            //MemberId先暫時用1帶入
            else
            {
                decimal price = _courseService.GetCourse25MinUnitPrice(CourseId);
                _shoppingCartService.CreateShoppingCartData(1, CourseId, 25, 1, price);
                return RedirectToAction("Index", "ShoppingCart");
            }
            
        }


        public IActionResult Success()
        {
            return View();
        }
    }

    
}
