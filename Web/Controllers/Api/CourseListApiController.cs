namespace Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseListApiController : ControllerBase
    {
        private readonly CourseService _courseService;
        public CourseListApiController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses([FromQuery] int page, [FromQuery] string subject = null, [FromQuery] string nation = null, [FromQuery] string weekdays = null, [FromQuery] string timeslots = null, [FromQuery] string budget = null)
        {
            if (page <= 0)
            {
                return BadRequest();
            }
            var courses = await _courseService.GetCourseCardsListAsync(page, 6, subject, nation, weekdays, timeslots, budget);
            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);
        }

        [HttpGet("GetTotalCourseQty")]
        public async Task<IActionResult> GetTotalCourseQty([FromQuery] string subject = null, [FromQuery] string nation = null, [FromQuery] string weekdays = null, [FromQuery] string timeslots = null, [FromQuery] string budget = null)
        {
            var courseQty = await _courseService.GetTotalCourseQtyAsync(subject, nation, weekdays, timeslots, budget);
            return Ok(courseQty);
        }

    }
}
