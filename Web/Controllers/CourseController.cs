using Web.Services;

namespace Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly CourseService _courseService;
        public CourseController(BookingService bookingService, CourseService courseService)
        {
            _bookingService = bookingService;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CourseList()
        {
            var model = await _courseService.GetCourseCardsList();
            return View(model);
        }

        public IActionResult WatchList()
        {
            return View();
        }
        public async Task<IActionResult> CourseMainPage()
        {
            var model = await _courseService.GetCourseMainPage();
            return View(model);
        }
    }
}
