using Api.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Api.Services
{
    public class ReviewApiService
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<Course> _courseRepository;

        public ReviewApiService(IRepository<Member> memberRepository, IRepository<Review> reviewRepository, IRepository<Course> courseRepository)
        {
            _memberRepository = memberRepository;
            _reviewRepository = reviewRepository;
            _courseRepository = courseRepository;
        }

        public async Task<List<ReviewDto>> GetAllReviews()
        {
            var reviews = await _reviewRepository.ListAsync();

            var result = new List<ReviewDto>();

            foreach (var review in reviews)
            {
                // 留言者
                var member = await _memberRepository.GetByIdAsync(review.StudentId);
                var course = await _courseRepository.GetByIdAsync(review.CourseId);

                var reResult = new ReviewDto
                {
                    ReviewId = review.ReviewId,
                    CourseTitle = course.Title,
                    Rating = review.Rating,
                    CommentText = review.CommentText,
                    FullName = member.FirstName + " " + member.LastName,
                    CreateDateTime = review.Cdate.ToString("yyyy-MM-dd hh:mm:ss"),
                };
                result.Add(reResult);
            }
            return result;
        }
    }
}
