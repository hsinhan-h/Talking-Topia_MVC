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
        public async Task<IActionResult> GetCourses([FromQuery] int page)
        {
            var courses = await _courseService.GetCourseCardsListAsync(page, 6);
            return Ok(courses);
        }

        [HttpGet("GetTotalCourseQty")]
        public async Task<IActionResult> GetTotalCourseQty()
        {
            var courseQty = await _courseService.GetTotalCourseQtyAsync();
            return Ok(courseQty);
        }


    }
}
