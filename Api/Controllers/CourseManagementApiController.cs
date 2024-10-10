using Api.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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
        public async Task<ActionResult> GetCourseManagementData()
        {
            try
            {
                var courseManagementData = await _courseManagementApiService.GetCourseManagementData();
                return Ok(courseManagementData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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

        [HttpGet]
        public async Task<ActionResult> GetUnapprovedCourseQtyStartingFrom2024()
        {
            try
            {
                var unapprovedCourseQty = await _courseManagementApiService.GetUnapprovedCourseQtyStartingFrom2024();
                return Ok(unapprovedCourseQty);
            }         
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetApprovedCourseQtyStartingFrom2024()
        {
            try
            {
                var approvedCourseQty = await _courseManagementApiService.GetApprovedCourseQtyStartingFrom2024();
                return Ok(approvedCourseQty);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetRejectedCourseQtyStartingFrom2024()
        {
            try
            {
                var rejectedCourseQty = await _courseManagementApiService.GetRejectedCourseQtyStartingFrom2024();
                return Ok(rejectedCourseQty);
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
