namespace Web.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Category { get; set; }
        public string SubjectId { get; set; }
        public int MemberId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public decimal TrialPriceNTD { get; set; }
        public decimal TwentyFiveMinPriceNTD { get; set; }
        public decimal FiftyMinPriceNTD { get; set; }
        public string Description { get; set; }
        public DateTime Publish { get; set; }
        public DateTime UpdateDatetime { get; set; }
        public bool Status { get; set; }
        public string Thumbnail { get; set; }
        public string VideoUrl { get; set; }

    }
}
