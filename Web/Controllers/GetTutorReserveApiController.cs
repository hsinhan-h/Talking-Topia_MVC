using Microsoft.AspNetCore.Mvc;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/GetTutorReserveApi")]
    public class GetTutorReserveApiController : Controller
    {
        private readonly TutorDataservice _tutorDataService;
        public GetTutorReserveApiController(TutorDataservice tutorDataservice)
        {
            _tutorDataService = tutorDataservice;
        }
        //轉成Json的方法
        [HttpGet("GetTutorReserveTimeJson")]
        public async Task<IActionResult> GetTutorReserveTimeJson(int memberId)
        {
            var tutortime = await _tutorDataService.GetTutorReserveTimeAsync(memberId);
            if (tutortime == null)
            {
                return NotFound();//如果後端取不到資料要返回404??
            }
            // 返回 JSON 給前端
            return Ok(tutortime);
        }
    }
}
