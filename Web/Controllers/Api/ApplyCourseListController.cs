using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyCourseListController : ControllerBase
    {

        private readonly ResumeDataService _resumeDataService;
        private readonly IMemberService _memberService;

        public ApplyCourseListController(ResumeDataService resumeDataService, IMemberService memberService)
        {
            _resumeDataService = resumeDataService;
            _memberService = memberService;
        }
        [HttpGet("ResumeApplyCouseData")]
        public async Task<IActionResult> ResumeApplyCouseData()
        {
            try
            {
                var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (memberIdClaim == null)
                { return RedirectToAction(nameof(AccountController.Account), "Account"); }
                int memberId = int.Parse(memberIdClaim.Value);
                var result = await _memberService.GetMemberId(memberId);
                var applycoursedataJson = await _resumeDataService.ReadApplyCourseData(memberId);
                var professionalLicenseJson = await _resumeDataService.ReadProfessionalLicense(memberId);
                var workexpJson = await _resumeDataService.ReadWorkexp(memberId);
                if (applycoursedataJson == null)
                {
                    return NotFound(new { success = false, message = "No course data found for the member." });
                }

                // 返回資料並回傳成功
                return Ok(new 
                { success = true,
                    data = new
                    {
                        applycoursedata = applycoursedataJson,
                        professionalLicense = professionalLicenseJson,
                        workexp = workexpJson,
                    }
                });
            }
            catch (Exception ex)
            {
                // 捕捉異常並記錄錯誤
                // 使用 logger 記錄詳細錯誤信息
                Console.WriteLine("Error: " + ex.Message);  // 或者使用更適合的 ILogger 來記錄錯誤
                return StatusCode(500, new { success = false, message = "An error occurred on the server.", details = ex.Message });
            }
        }

    }
}
