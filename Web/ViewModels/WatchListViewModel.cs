namespace Web.ViewModels
{
    public class WatchListViewModel
    {
        /// <summary>
        /// 教師頭像
        /// </summary>
        public string HeadShotImageUrl { get; set; }
        /// <summary>
        /// 教師國旗圖像
        /// </summary>
        public string NationImage { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 課程副標題
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// 教師簡介
        /// </summary>
        public string TeacherIntroduction { get; set; }
        /// <summary>
        /// 體驗台幣價格
        /// </summary>
        public decimal TrialPriceNTD { get; set; }
        /// <summary>
        /// 50分鐘台幣價格
        /// </summary>
        public decimal FiftyMinPriceNTD { get; set; }
        /// <summary>
        /// 評分 (星星)
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// 關注狀態
        /// </summary>
        public bool IsFollowed { get; set; }
    }
}
