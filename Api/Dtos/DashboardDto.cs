namespace Api.Dtos
{
    public class DashboardDto
    {
        /// <summary>
        /// 今日新增會員數量
        /// </summary>
        public int MemberTodayCount { get; set; }
        /// <summary>
        /// 較昨日業績成長佔比
        /// </summary>
        public double Proportion { get; set; }
        /// <summary>
        /// 本日熱銷課程
        /// </summary>
        public string PopularCourse { get; set; }
        /// <summary>
        /// 最熱門科目
        /// </summary>
        public string FirstCourseName { get; set; }
        /// <summary>
        /// 次熱門科目
        /// </summary>
        public string SecondCourseName { get; set; }
        /// <summary>
        /// 最熱門科目業績
        /// </summary>
        public int[] FirstCourseData { get; set; }
        /// <summary>
        /// 次熱門科目業績
        /// </summary>
        public int[] SecondCourseData { get; set; }
        /// <summary>
        /// 總銷售堂數
        /// </summary>
        public int[] OrderQuantityData { get;set; }
        /// <summary>
        /// 實際預約堂數
        /// </summary>
        public int[] BookingQuantiyData { get;set; }
    }
}
