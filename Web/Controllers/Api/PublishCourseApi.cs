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
        public async Task<IActionResult> SaveToCoures([FromBody] CourseDataViewModel course)
        {
            int memberId = 3;

            //var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            //if(memberIdClaim == null) {return BadRequest("請重新登入");}
            //memberId = int.Parse(memberIdClaim.Value);
            //var result = await _memberService.GetMemberId(memberId);
            //if(!result) { return BadRequest("找不到會員"); }

            if (string.IsNullOrWhiteSpace(course.CategoryId))
            {
                return BadRequest("課程分類為必填欄位");
            }
            if (course.SubjectId == 0)
            {
                return BadRequest("課程科目為必填欄位");
            }
            if (course.ThumbnailUrl == null)
            {
                return BadRequest("自介照片為必上傳欄位");
            }
            if (string.IsNullOrWhiteSpace(course.VideoUrl))
            {
                return BadRequest("自介影片為必填欄位");
            }
            if (course.CouresImagesList == null)
            {
                return BadRequest("課程圖片為必上傳欄位");
            }
            if (string.IsNullOrWhiteSpace(course.Title))
            {
                return BadRequest("課程名稱為必填欄位");
            }
            if (string.IsNullOrWhiteSpace(course.SubTitle))
            {
                return BadRequest("課程簡述為必填欄位");
            }

            await _bookingService.SaveCourse(CRUDStatus.Create, course, memberId);

            return Ok("新增成功");
        }

        /// <summary>
        /// 取課程科目列表資料
        /// </summary>
        /// <param name="courseCategoryId"></param>
        /// <returns></returns>
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
