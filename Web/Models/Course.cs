namespace Web.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int MemberID { get; set; } //FK
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int ReceivedReviews { get; set; }
        public int TrialPriceNTD { get; set; }
        public int TwentyFiveMinPriceNTD { get; set; }
        public int FiftyMinPriceNTD { get; set; }
        public string Description { get; set; }
        public Tuple<string, string> IntroVideo { get; set; }
        public List<string> IntroImages { get; set; }

    }
}
