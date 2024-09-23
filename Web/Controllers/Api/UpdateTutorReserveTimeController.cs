using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateTutorReserveTimeController : ControllerBase
    {
        private readonly TutorDataservice _tutorDataService;

        public UpdateTutorReserveTimeController(TutorDataservice tutorDataservice)
        {
            _tutorDataService = tutorDataservice;
        }

        // 轉成 Json 的方法
        [HttpPost]
        [Route("UpdateTutorReserveTime")]
        public async Task<IActionResult> UpdateTutorReserveTime(int memberId)
        {
            try
            {
                // 1. 刪除該會員的舊有時段資料
                await _tutorDataService.DeleteTimeSlotsForMember(memberId);
                return Ok(new { success = true });

            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
