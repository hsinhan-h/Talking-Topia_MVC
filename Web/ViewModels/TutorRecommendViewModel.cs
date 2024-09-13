namespace Web.ViewModels
{
    public class TutorRecommendCardViewModel
    {
        public int MemberId { get; set; }
        public int SubjectId { get; set; }
        public int CategoryId { get; set; }
        public List<TutorRecomCardList> TutorReconmmendCard { get; set; } 
    }

    public class TutorRecomCardList
    {        
        public int CourseId { get; set; }
        public string TutorHeadShot { get; set; }
        public string NationFlagImg { get; set; }
        public string CourseTitle { get; set; }
        public string CourseSubTitle { get; set; }
        public int TwentyFiveMinPrice { get; set; }
        public int FiftyminPrice { get; set; }
        public double Rating { get; set; }
        public string Description   { get; set; }
    }
}
