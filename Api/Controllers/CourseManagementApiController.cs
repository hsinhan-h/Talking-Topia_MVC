using Api.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseManagementApiController : ControllerBase
    {
        private readonly CourseManagementApiService _courseManagementApiService;

        public CourseManagementApiController(CourseManagementApiService courseManagementApiService)
        {
            _courseManagementApiService = courseManagementApiService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCourseApprovalList()
        {
            try
            {
                var courseApprovalList = await _courseManagementApiService.GetCourseApprovalList();
                return Ok(courseApprovalList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCoursesStatus([FromBody] UpdateCoursesStatusDto dto)
        {
            try
            {
                var result = await _courseManagementApiService.UpdateCoursesStatus(dto.CourseId, dto.CourseApprove);

                if (result)
                {
                    return Ok("更新課程審核資訊成功!");
                }
                else
                {
                    return BadRequest("更新課程審核資訊失敗!");
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
