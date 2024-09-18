using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseReviewRatingValueController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseReviewRatingValueController(CourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public ActionResult<int> CourseReviewApi([FromQuery]int courseId)
        {
            var review = _courseService.GetCourseRating(courseId);
            

            return Ok(review);
        }
    }
}
