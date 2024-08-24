using Web.Services;

namespace Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly BookingService _bookingService;
        public CourseController()
        {
            _bookingService = new BookingService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CourseList()
        {
            return View();
        }
        public IActionResult WatchList()
        {
            return View();
        }
        public async Task<IActionResult> PublishCourse()
        {
            var model = await _bookingService.GetBookingList();
            return View(model);
        }
        public IActionResult CourseMainPage()
        {
            return View();
        }
    }
}
