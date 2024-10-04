using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using System.ComponentModel;
using System.Security.Claims;
using Web.Services;
using BookingService = Web.Services.BookingService;

namespace Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly CourseService _courseService;
        private readonly ICourseService _icourseService;
        private readonly IMemberService _memberService;


        public CourseController(BookingService bookingService, CourseService courseService, ICourseService icourseService, IMemberService memberService)
        {
            _bookingService = bookingService;
            _courseService = courseService;
            _icourseService = icourseService;
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CourseList()
        {
            return View();
        }


        public async Task<IActionResult> CourseMainPage([FromQuery, DefaultValue(1)] int courseId)
        {
            ViewData["CourseId"] = courseId;

            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            int memberId = 0;

            // 如果找到 memberIdClaim，將其解析成整數
            if (memberIdClaim != null)
            {
                memberId = int.Parse(memberIdClaim.Value);
            }
            ViewData["MemberId"] = memberId;

            var model = await _courseService.GetCourseMainPage(courseId,memberId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseReview([FromForm] int CourseId,[FromForm]byte rating, [FromForm] string NewReviewContent)
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            try
            {
                var createReview = _icourseService.CreateReviews(memberId,CourseId, rating, NewReviewContent);
                return RedirectToAction(nameof(CourseMainPage), new { courseId =CourseId });
            }
            catch (Exception ex)
            {               
                return Content("評論建立失敗!"); 
            }
        }

       

        

    }

    
}
