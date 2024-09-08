using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BookingController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart()
        {
            //Console.WriteLine($"BookingDate: {BookingDate}, BookingTime: {BookingTime}");
            return RedirectToAction("Success", "Booking");
        }


        public IActionResult Success()
        {
            return View();
        }
    }

    
}
