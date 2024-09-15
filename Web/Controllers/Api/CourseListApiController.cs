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
        public async Task<IActionResult> GetCourses([FromQuery] int page, [FromQuery] string nation = null)
        {
            var courses = await _courseService.GetCourseCardsListAsync(page, 6, nation);
            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);
        }

        [HttpGet("GetTotalCourseQty")]
        public async Task<IActionResult> GetTotalCourseQty([FromQuery] string nation = null)
        {
            var courseQty = await _courseService.GetTotalCourseQtyAsync(nation);
            return Ok(courseQty);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetCourses([FromQuery] int page, [FromQuery] string nation)
        //{
        //    var courses = await _courseService.GetCourseCardsListAsync(page, 6, nation);
        //    return Ok(courses);
        //}
    }
}
