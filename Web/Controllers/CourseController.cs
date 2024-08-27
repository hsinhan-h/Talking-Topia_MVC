using Web.Services;

namespace Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly CourseService _courseService;
        public CourseController()
        {
            _bookingService = new BookingService();
            _courseService = new CourseService();
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
        public async Task<IActionResult> PublishCourse()
        {
            var model = await _bookingService.GetPublishCourseList();
            return View(model);
        }
        public async Task<IActionResult> CourseMainPage()
        {
            var model = await _courseService.GetCourseMainPage();
            return View(model);
        }
    }
}
