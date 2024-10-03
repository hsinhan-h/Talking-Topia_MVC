using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Web.Services
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(IConfiguration configuration)
        {
            var cloudinaryAccount = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]);

            _cloudinary = new Cloudinary(cloudinaryAccount);
        }
        public async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            if (imageFile.Length > 0)
            {
                using (var stream = imageFile.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(imageFile.FileName, stream)
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    return uploadResult.SecureUrl.ToString();
                }
            }

            return null;
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new RawUploadParams() // RawUploadParams can handle non-image files.
                    {
                        File = new FileDescription(file.FileName, stream)
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    return uploadResult.SecureUrl.ToString();
                }
            }

            return null;
        }
    }
}
