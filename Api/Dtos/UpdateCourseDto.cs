namespace Api.Dtos
{
    public class UpdateCourseDto
    {
        public int CourseId { get; set; }

        /// <summary>
        /// 課程標題
        /// </summary>
        public string? CourseTitle { get; set; }

        /// <summary>
        /// 課程副標題
        /// </summary>
        public string? CourseSubTitle { get; set; }

        /// <summary>
        /// 課程分類Id
        /// </summary>
        public int CourseCategory { get; set; }

        /// <summary>
        /// 課程科目Id
        /// </summary>
        public int CourseSubject { get; set; }

        /// <summary>
        /// 課程介紹
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 課程圖片
        /// </summary>
        public List<string>? CourseImages { get; set; }

        /// <summary>
        /// 25分鐘價格
        /// </summary>
        public decimal? TwentyFiveMinUnitPrice { get; set; }

        /// <summary>
        /// 50分鐘價格
        /// </summary>
        public decimal? FiftyMinUnitPrice { get; set; }

        /// <summary>
        /// 影片封面
        /// </summary>
        public string? ThumbnailUrl { get; set; }

        /// <summary>
        /// 自介影片
        /// </summary>
        public string? VideoUrl { get; set; }
    }
}
