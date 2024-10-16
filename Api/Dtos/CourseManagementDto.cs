using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class CourseManagementDto
    {
        public int CourseId { get; set; }

        /// <summary>
        /// 課程標題
        /// </summary>
        public string CourseTitle { get; set; }

        /// <summary>
        /// 課程副標題
        /// </summary>
        public string CourseSubTitle { get; set; }

        /// <summary>
        /// 教師姓名
        /// </summary>
        public string TutorName { get; set; }

        /// <summary>
        /// 課程分類
        /// </summary>
        public string CourseCategory { get; set; }

        /// <summary>
        /// 課程科目
        /// </summary>
        public string CourseSubject { get; set; }

        /// <summary>
        /// 課程介紹
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 課程圖片
        /// </summary>
        public List<string>? CourseImages { get; set; }

        /// <summary>
        /// 上架狀態
        /// </summary>
        public bool PublishStatus { get; set; }

        /// <summary>
        /// 上架日期
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// 課程審核狀態 (是否為審核中?)
        /// </summary>
        public bool IsUnderReview { get; set; }

        /// <summary>
        /// 25分鐘價格
        /// </summary>
        public decimal TwentyFiveMinUnitPrice { get; set; }

        /// <summary>
        /// 50分鐘價格
        /// </summary>
        public decimal FiftyMinUnitPrice { get; set; }

        /// <summary>
        /// 影片封面
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// 自介影片
        /// </summary>
        public string VideoUrl { get; set; }

    }
}
