using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Api.Services
{
    public class CourseImageService
    {
        private readonly IRepository<CourseImage> _courseImageRepository;

        public CourseImageService(IRepository<CourseImage> courseImageRepository)
        {
            _courseImageRepository = courseImageRepository;
        }

        public async Task SaveCourseImagesAsync(int courseId, List<string> imageUrls)
        {
            var courseImages = imageUrls.Select(imgUrl => new CourseImage
            {
                CourseId = courseId,
                ImageUrl = imgUrl,
                Cdate = DateTime.Now
            }).ToList();

            await _courseImageRepository.AddRangeAsync(courseImages);
        }

    }
}
