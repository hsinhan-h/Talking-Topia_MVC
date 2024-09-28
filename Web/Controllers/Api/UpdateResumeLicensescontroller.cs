using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class UpdateResumeController : ControllerBase
    {
        private readonly ResumeDataService _resumeDataService;
        private readonly CloudinaryService _cloudinaryService;
        private readonly IRepository _repository;

        public UpdateResumeController(ResumeDataService resumeDataService, CloudinaryService cloudinaryService, IRepository repository)
        {
            _resumeDataService = resumeDataService;
            _cloudinaryService = cloudinaryService;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateResumeLicenses([FromForm] TutorResumeViewModel model)
        {
            try
            {
                // 獲取上傳的文件（如果有多個文件）
                var files = Request.Form.Files;
                var fileUrls = new List<string>();

                // 遍歷每個文件，逐一上傳
                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {
                        // 使用 Cloudinary 上傳，並取得返回的 URL
                        var fileUrl = await _cloudinaryService.UploadImageAsync(file);
                        fileUrls.Add(fileUrl);
                    }
                }

                // 如果沒有上傳新文件，則使用原本的 URL 列表
                if (!fileUrls.Any())
                {
                    fileUrls = model.ProfessionalLicenseUrl;
                }

                // 調用服務層，更新資料庫中的證照資料
                await _resumeDataService.ChangeResumeLicenses(model.memberId, model.ProfessionalLicenseId, model.ProfessionalLicenseName, fileUrls);

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLicense([FromBody] TutorResumeViewModel request)
        {

            // 調用服務層來刪除證照
            var result = await _resumeDataService.DeleteLicensesAsync(request.memberId, request.ProfessionalLicenseId);

            if (!result.Success)
            {
                return BadRequest(new { success = false, message = result.Message });
            }

            return Ok(new { success = true, message = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> CreateLicense([FromBody] TutorResumeViewModel request)
        {

            try
            {
                // 創建一個新的 ProfessionalLicense 並儲存到資料庫
                var newLicense = new ProfessionalLicense
                {
                    MemberId = request.memberId,
                    ProfessionalLicenseName = string.Empty, // 初始化為空，稍後更新
                    ProfessionalLicenseUrl = string.Empty,  // 初始化為空，稍後更新
                    Cdate = DateTime.Now,
                    Udate = null
                };

                // 將新證照保存到資料庫
                _repository.Create(newLicense);
                await _repository.SaveChangesAsync();

                // 返回新生成的 ProfessionalLicenseId
                return Ok(new { success = true, newLicense.ProfessionalLicenseId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


    }
}
