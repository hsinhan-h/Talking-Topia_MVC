using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudinaryApiController : ControllerBase
    {
        private readonly CloudinaryService _cloudinaryService;

        public CloudinaryApiController(CloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
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
                //ViewBag.ImageUrl = imageUrl;
            }
            return Ok();
        }
    }
}
