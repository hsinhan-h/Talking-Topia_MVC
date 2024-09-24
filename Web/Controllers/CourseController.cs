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
            //int pageSize = 6;
            //int totalCourseQty = await _courseService.GetTotalCourseQtyAsync();
            //int totalPages =  (int)Math.Ceiling((double)totalCourseQty / pageSize);
            //ViewData["TotalPages"] = totalPages;
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

        [HttpPost]
        public async Task<IActionResult> AddFollowingCourse([FromForm]int CourseId)
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            try
            {
                var addWatchList = _memberService.AddWatchList(memberId, CourseId);
                return RedirectToAction(nameof(CourseMainPage), new { courseId = CourseId });

            }
            catch (Exception ex) 
            {
                return Content("新增關注失敗!");

            }



        }

    }

    
}
