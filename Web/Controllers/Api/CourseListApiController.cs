using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Security.Claims;

namespace Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseListApiController : ControllerBase
    {
        private readonly CourseService _courseService;
        private readonly IMemberService _memberService;
        public CourseListApiController(CourseService courseService, IMemberService memberService)
        {
            _courseService = courseService;
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses(
            [FromQuery] int page, 
            [FromQuery] string subject = null, 
            [FromQuery] string nation = null, 
            [FromQuery] string weekdays = null, 
            [FromQuery] string timeslots = null, 
            [FromQuery] string budget = null,
            [FromQuery] string sortOption = null
            )
        {
            if (page <= 0)
            {
                return BadRequest();
            }

            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            int memberId = 0;  //預設的匿名或訪客用戶Id
            if (memberIdClaim != null)
            {
                memberId = int.Parse(memberIdClaim.Value);
            }

            var courses = await _courseService.GetCourseCardsListAsync(page, 6, memberId, subject, nation, weekdays, timeslots, budget, sortOption);
            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);
        }

    }
}
