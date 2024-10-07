using Api.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberManagermentApiController : ControllerBase
    {
        private readonly MemberManagermentApiService _memberManagermentApiService;

        public MemberManagermentApiController(MemberManagermentApiService memberManagermentApiService)
        {
            _memberManagermentApiService = memberManagermentApiService;
        }
        [HttpGet]
        public async Task<ActionResult> GetMemberDataList()
        {
            try
            {
                var allmemberdatalList = await _memberManagermentApiService.GetMemberDataList();
                return Ok(allmemberdatalList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMemberDataList([FromBody] MemberDataDto dto)
        {
            try
            {
                var result = await _memberManagermentApiService.UpdateMemberData(dto);

                if (result)
                {
                    return Ok("會員資料更新成功!");
                }
                else
                {
                    return BadRequest("會員資料更新失敗!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetTutorDataList()
        {
            try
            {
                var allTutordatalList = await _memberManagermentApiService.GetTutorDataList();
                return Ok(allTutordatalList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
