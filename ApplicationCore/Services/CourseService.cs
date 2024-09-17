using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Review> _reviewRepository;

       

        public CourseService(IRepository<Course> courseRepository, IRepository<Review> reviewRepository)
        {
            _courseRepository = courseRepository;
            _reviewRepository = reviewRepository;
        }

        public bool IsCourse(int courseId)
        {
            return _courseRepository.Any(c => c.CourseId == courseId);
        }

        public int CreateReviews(int studentId, int courseId, string NewReviewContent)
        {
            try
            {                
                var reviewEntity = new Review()
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    CommentText = NewReviewContent,
                    Cdate = DateTime.Now
                };
                var review =_reviewRepository.Add(reviewEntity);
                if (review is null)
                {
                    throw new Exception("Review could not be created");
                }
                return review.ReviewId;
            }
            catch (Exception ex)
            {
                throw new Exception("Review could not be created", ex);
            }

        }
    
    }
}
