namespace Web.Dtos
{
    public class CourseReviewListDto
    {
        public List<CourseReview> CourseReviewList { get; set; }

    }

    public class CourseReview
    {
        public double CommentRating { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewDate { get; set; }
        public string ReviewContent { get; set; }
    }
}
