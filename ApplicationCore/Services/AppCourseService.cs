using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class AppCourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Review> _reviewRepository;

       

        public AppCourseService(IRepository<Course> courseRepository, IRepository<Review> reviewRepository)
        {
            _courseRepository = courseRepository;
            _reviewRepository = reviewRepository;
        }

        public bool IsCourse(int courseId)
        {
            return _courseRepository.Any(c => c.CourseId == courseId);
        }

        public int GetReviewRatingApiService(int courseId) 
        {
            var reviewRatings = _reviewRepository.List()
                          .Where(r => r.CourseId == courseId)
                          .Select(r => (int)r.Rating);

            if (!reviewRatings.Any())
            {
                return 0; 
            }

            return (int)Math.Round(reviewRatings.Average());
        }

    }
}
