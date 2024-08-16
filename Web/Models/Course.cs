namespace Web.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int MemberID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int ReceivedReviews { get; set; }
        public int TrialPrice { get; set; }
        public int TwentyFiveMinPrice { get; set; }
        public int FiftyMinPrice { get; set; }
        public int Description { get; set; }
        public string[] IntroMedias { get; set; }
        public string[] IntroMediaThumnails { get; set; }

    }
}
