using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishCourseApi : ControllerBase
    {
        private readonly BookingService _bookingService;
        public PublishCourseApi(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{CourseId}")]
        public async Task<IActionResult> GetBookingDetails(int CourseId)
        {
            int memberId = 3;
            var booking = await _bookingService.GetPublishCourse(memberId, CourseId);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        /// <summary>
        /// 課程儲存
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        [HttpPost("SaveToCouresData")]
        //public async Task<IActionResult> SaveToCoures()
        public async Task<IActionResult> SaveToCoures([FromBody] CourseDetailDto Category)
        {
            int memberId = 3;
            var course = new Course()
            {

            };
            var courseImg = new CourseImage
            {

            };
            _bookingService.SaveCourse(CRUDStatus.Create, course, courseImg);


            return Ok();
        }
        //暫時
        public class CourseDetailDto
        {
            public string CourseCategory { get; set; }
            public string SubTitle { get; set; } // 添加與前端相匹配的屬性
        }

        [HttpGet("GetSubjectsByCategoryId/{courseCategoryId}")]
        public IActionResult GetSubjectsByCategoryId(int courseCategoryId)
        {
            var subjects = _bookingService.GetSubjectsByCategoryId(courseCategoryId);
            if (subjects == null || !subjects.Any())
            {
                return NotFound("找不到課程科目");
            }

            return Ok(subjects);
        }
    }
}
