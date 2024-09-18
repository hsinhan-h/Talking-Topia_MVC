using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers.Api
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
            var courseInfoListViewModel = await _courseService.GetBookingTableAsync(courseId);

            if (courseInfoListViewModel == null)
            {
                return NotFound();
            }

            return Ok(courseInfoListViewModel);
        }

    }
}


