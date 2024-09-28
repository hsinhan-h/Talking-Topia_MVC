using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FollowingController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public FollowingController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public ActionResult GetFollowStatus([FromQuery]int courseId)
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            int memberId = 0;

            // 如果找到 memberIdClaim，將其解析成整數
            if (memberIdClaim != null)
            {
                memberId = int.Parse(memberIdClaim.Value);
            }
            var isFollowed = _memberService.IsWatched(memberId, courseId);
            return Ok(isFollowed);
        }

        [HttpPost]
        public ActionResult<bool> AddFollowing([FromBody] WatchViewModel wVM)
        {
            if (wVM != null)
            {
                // 使用模型中的 followerId 和 followedUserId 進行業務邏輯處理，例如寫入資料庫
                var isSuccess = _memberService.AddWatchList(wVM.FollowerId, wVM.FollowedCourseId);

                if (isSuccess != 0)
                {
                    return Ok(new { success = true, message = "你成功關注了!!" });
                }
            }
            return Ok(new { success = false, message = "Oops!好像發生了一點意外" });            
        }

        [HttpPost]
        public ActionResult<bool> DeleteFollowingCourse([FromBody] WatchViewModel wVM)
        {
            if (wVM != null)
            {
                // 使用模型中的 followerId 和 followedUserId 進行業務邏輯處理，例如寫入資料庫
                var isSuccess = _memberService.DeleteWatchList(wVM.FollowerId, wVM.FollowedCourseId);

                if (isSuccess)
                {
                    return Ok(new { success = true, message = "你已取消關注此課程!!" });
                }
            }
            return Ok(new { success = false, message = "Oops!好像發生了一點意外" });
        }



    }
}
