using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseReviewRatingValueController : ControllerBase
    {
        private readonly ApplicationCore.Services.CourseService _courseService;

        public CourseReviewRatingValueController(ApplicationCore.Services.CourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public IActionResult CourseReviewApi(int courseId)
        {
            var review = _courseService.GetReviewRatingApiService(courseId);
            return Ok(review);
        }
    }
}
