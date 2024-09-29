using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseReviewController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseReviewController(CourseService courseService)
        {
            _courseService = courseService;
            
        }


        [HttpGet]
        public ActionResult<int> CourseReviewApi([FromQuery]int courseId)
        {
            var review = _courseService.GetCourseRating(courseId);
            return Ok(review);
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseReviewList([FromQuery] int courseId) 
        {
            var getCourseReviewList = await _courseService.GetReviewList(courseId);
            var courseReviewCards = getCourseReviewList.CourseReviewList;
            var result = JsonConvert.SerializeObject(courseReviewCards);
            return Ok(result);
        }       
    }
}
