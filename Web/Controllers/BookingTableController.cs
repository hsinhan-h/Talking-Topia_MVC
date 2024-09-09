using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BookingTableController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int CourseId)
        {
            //Console.WriteLine($"BookingDate: {BookingDate}, BookingTime: {BookingTime}");

            // todo: 剩餘堂數 > 0, 允許預約
            // 寫入booking資料表, 導向預約成功頁面


            //todo: 剩餘堂數 <= 0, 跳轉購物車, 將課程寫入購物車資料表


            return RedirectToAction("Success", "BookingTable");
        }


        public IActionResult Success()
        {
            return View();
        }
    }

    
}
