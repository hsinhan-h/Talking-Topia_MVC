using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICourseService
    {
        public bool IsCourse(int courseId);

        public int CreateReviews(int studentId, int courseId, byte NewReviewRating, string NewReviewContent);

        public int GetReviewRatingApiService(int courseId);
    }
}
