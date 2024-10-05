using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
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

        [HttpGet]
        public IActionResult ReviewRules([FromQuery] int courseId)
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            int memberId = 0;

            // 如果找到 memberIdClaim，將其解析成整數
            if (memberIdClaim != null)
            {
                memberId = int.Parse(memberIdClaim.Value);
            }

            var reviewButton = _courseService.GetReviewInfo(memberId, courseId);
            var result = JsonConvert.SerializeObject(reviewButton);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCourseReview([FromForm] int memberId, [FromForm] int courseId, [FromForm] byte rating, [FromForm] string newReviewContent)
        {
            try
            {
                _courseService.CreateReviews(memberId, courseId, rating, newReviewContent);
                return Ok(new { success = true, message = "你成功新增評論!!" });
            }
            catch (Exception ex)
            {
                return Content("評論建立失敗!");
            }
        }
    }
}
