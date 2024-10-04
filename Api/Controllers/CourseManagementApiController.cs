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


    }
}
