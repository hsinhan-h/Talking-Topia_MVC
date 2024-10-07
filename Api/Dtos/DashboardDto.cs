namespace Api.Dtos
{
    public class DashboardDto
    {
        /// <summary>
        /// 會員總數
        /// </summary>
        public int MemberTotalCount { get; set; }
        /// <summary>
        /// 今日新增會員數量
        /// </summary>
        public int MemberTodayCount { get; set; }
        /// <summary>
        /// 本日業績
        /// </summary>
        public int DailyPerformance { get; set; }
        /// <summary>
        /// 較昨日業績成長佔比
        /// </summary>
        public double Proportion { get; set; }
        /// <summary>
        /// 本月熱銷課程
        /// </summary>
        public string PopularCourse { get; set; }
        /// <summary>
        /// 當日熱銷課程新增訂單筆數
        /// </summary>
        public int DailyPopularOrderCount { get; set; }
        /// <summary>
        /// 本月優質課程
        /// </summary>
        public string TopCourse { get; set; }
        /// <summary>
        /// 當日優質課程新增評論筆數
        /// </summary>
        public int DailyTopReviewCount { get; set; }
    }
}
