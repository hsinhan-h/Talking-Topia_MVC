namespace Web.ViewModels
{
    public class WatchListViewModel
    {
        public List<WatchListViewModel> WatchList { get; set; }
    }
    public class WatchViewModel
    {
        /// <summary>
        /// 教師頭像
        /// </summary>
        public string HeadShotImage { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string CourseTitle { get; set; }

        /// <summary>
        /// 課程科目
        /// </summary>
        public string CourseSubject { get; set; }

        /// <summary>
        /// 教師簡介
        /// </summary>
        public string TutorIntro { get; set; }
        /// <summary>
        /// 25分鐘價格
        /// </summary>
        public int TwentyFiveMinPriceNTD { get; set; }
        /// <summary>
        /// 50分鐘價格
        /// </summary>
        public int FiftyMinPriceNTD { get; set; }

    }
}
