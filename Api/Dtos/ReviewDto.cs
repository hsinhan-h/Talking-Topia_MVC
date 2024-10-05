namespace Api.Dtos
{
    public class ReviewDto
    {
        /// <summary>
        /// 評論編號
        /// </summary>
        public int ReviewId { get; set; }
        /// <summary>
        /// 被評論課程
        /// </summary>
        public string CourseTitle { get; set; }
        /// <summary>
        /// 評分
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// 評論內容
        /// </summary>
        public string CommentText { get; set; }
        /// <summary>
        /// 評論的人
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 評論時間
        /// </summary>
        public string CreateDateTime { get; set; }
    }
}
