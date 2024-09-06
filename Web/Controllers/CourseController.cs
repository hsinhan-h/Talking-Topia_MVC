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

        public async Task<IActionResult> CourseList(int page = 1)
        {
            int pageSize = 6;
            int totalCourseQty = await _courseService.GetTotalCourseQty();
            int totalPages =  (int)Math.Ceiling((double)totalCourseQty / pageSize);
            ViewData["TotalPages"] = totalPages;
            var model = await _courseService.GetCourseCardsListAsync(page, pageSize);
            return View(model);
        }

        public async Task<IActionResult> CourseMainPage([FromQuery] int courseid)
        {
            var model = await _courseService.GetCourseMainPage(courseid);
            return View(model);
        }
    }
}
