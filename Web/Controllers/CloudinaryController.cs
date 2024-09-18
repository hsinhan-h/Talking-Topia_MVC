using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CloudinaryController : Controller
    {
        private readonly CloudinaryService _cloudinaryService;

        public CloudinaryController(CloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile image)
        {
            if (image != null)
            {
                var imageUrl = await _cloudinaryService.UploadImageAsync(image);
                ViewBag.ImageUrl = imageUrl;
            }
            return View();
        }
    }
}
