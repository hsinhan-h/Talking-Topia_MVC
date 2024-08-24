namespace Web.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int MemberId { get; set; }
        public int CourseId { get; set; }
        public byte Rating { get; set; }
        public string CommentText { get; set; }
        public DateTime ReviewDate { get; set; }

    }
}
