using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class BookingListViewModel
    {
        public List<BookingViewModel> BookingList { get; set; }
    }
    public class BookingViewModel
    {
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime UpdateDatetime { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string CourseTitle { get; set; }
        /// <summary>
        /// 課程分類
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 課程科目
        /// </summary>
        public string CourseSubject { get; set; }
        /// <summary>
        /// 課程影片縮圖
        /// </summary>
        public string Thumbnail { get; set; }
        /// <summary>
        /// 課程影片
        /// </summary>
        public string VideoUrl { get; set; }
        /// <summary>
        /// 課程圖片
        /// </summary>
        public string CourseImageId { get; set; }
        /// <summary>
        /// 上架課程ID
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 課程內容
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// 教師自介
        /// </summary>
        public string TutorIntro { get; set; }
        /// <summary>
        /// 課程介紹
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 體驗價
        /// </summary>
        public decimal TrialPriceNTD { get; set; }
        /// <summary>
        /// 25分鐘價
        /// </summary>
        public decimal TwentyFiveMinPriceNTD { get; set; }
        /// <summary>
        /// 50分鐘價
        /// </summary>
        public decimal FiftyMinPriceNTD { get; set; }

        public int BookingId { get; set; }

        [DisplayName("上課時間")]
        public DateTime BookingDate { get; set; }
        public int BookingTime { get; set; }
        public int MemberId { get; set; }

        [DisplayName("上課時長")]
        public string CourseLength { get; set; }
        [DisplayName("學員名稱")]
        public string MemberName { get; set; }

    }
}
