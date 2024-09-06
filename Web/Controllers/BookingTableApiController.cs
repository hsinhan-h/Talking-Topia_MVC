using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/BookingTableApi")]
    public class BookingTableApiController : ControllerBase
    {

        private readonly CourseService _courseService;
        public BookingTableApiController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingTableAsync([FromQuery] int courseId)
        {
            var courseInfoListVIewModel = await _courseService.GetBookingTableAsync(courseId);

            if (courseInfoListVIewModel == null)
            {
                return NotFound();
            }

            return Ok(courseInfoListVIewModel);
        }

    }
}


