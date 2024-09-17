using ApplicationCore.Interfaces;
using System.ComponentModel;
using Web.Services;

namespace Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly CourseService _courseService;
        private readonly ICourseService _icourseService;
        public CourseController(BookingService bookingService, CourseService courseService, ICourseService icourseService)
        {
            _bookingService = bookingService;
            _courseService = courseService;
            _icourseService = icourseService;
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
            //var model = await _courseService.GetCourseCardsListAsync(page, pageSize);
            return View();
        }


        public async Task<IActionResult> CourseMainPage([FromQuery, DefaultValue(1)] int courseId)
        {
            ViewData["CourseId"] = courseId;
            var model = await _courseService.GetCourseMainPage(courseId);
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCourseReview([FromForm]byte rating, [FromForm] string NewReviewContent)
        {
           
            try 
            {
                var createReview = _icourseService.CreateReviews(2,2, rating, NewReviewContent);
                return RedirectToAction(nameof(CourseMainPage), new { courseId =2 });
               

            }
            catch (Exception ex)
            {               
                return Content("訂單建立失敗!");
               
            }
        }


    }

    
}
