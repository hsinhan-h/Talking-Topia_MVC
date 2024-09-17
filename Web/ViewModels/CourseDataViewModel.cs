namespace Web.ViewModels
{
    public class CourseDataViewModel
    {
        public int CourseId { get; set; }
        public string CategoryId { get; set; }
        public string SubjectId { get; set; }
        public List<string> ThumbnailUrl { get; set; }
        public List<string> VideoUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string TwentyFiveMinPriceNTD { get; set; }
        public string FiftyMinPriceNTD { get; set; }
        public List<string> CouresImagesList { get; set; }
        public string Description { get; set; } = "課程描述";
        public bool IsEnabled { get; set; } = true;
        public short CoursesStatus { get; set; } = 0;
    }
}
