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
            int totalCourseQty = await _courseService.GetTotalCourseQtyAsync();
            int totalPages =  (int)Math.Ceiling((double)totalCourseQty / pageSize);
            ViewData["TotalPages"] = totalPages;
            var model = await _courseService.GetCourseCardsListAsync(page, pageSize);
            return View(model);
        }

        //[HttpGet("api/BookingTable")]
        //public async Task<IActionResult> GetBookingTable([FromQuery] int courseId)
        //{
        //    var courseInfoListVIewModel = await _courseService.GetBookingTableAsync(courseId);
        //    return Ok(courseInfoListVIewModel);
        //}


        public async Task<IActionResult> CourseMainPage([FromQuery] int courseId)
        {
            var model = await _courseService.GetCourseMainPage(courseId);
            return View(model);
        }
    }


    
}
