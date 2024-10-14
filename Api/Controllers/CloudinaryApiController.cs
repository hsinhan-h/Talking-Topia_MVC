using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CloudinaryApiController : Controller
    {
        private readonly CloudinaryService _cloudinaryService;
        private readonly CourseImageService _courseImageService;

        public CloudinaryApiController(CloudinaryService cloudinaryService, CourseImageService courseImageService)
        {
            _cloudinaryService = cloudinaryService;
            _courseImageService = courseImageService;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile image)
        {
            if (image != null)
            {
                var imageUrl = await _cloudinaryService.UploadImageAsync(image);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages([FromForm] List<IFormFile> images, [FromQuery] int courseId)
        {

            if (images == null || !images.Any())
            {
                return BadRequest("沒有圖片");
            }

            var imageUrls = new List<string>();
            foreach (var image in images)
            {
                var imageUrl = await _cloudinaryService.UploadImageAsync(image);
                imageUrls.Add(imageUrl); // 保存圖片路徑
            }
            await _courseImageService.SaveCourseImagesAsync(courseId, imageUrls);

            return Ok(imageUrls); // 回傳圖片的檔案名
        }
    }
}
