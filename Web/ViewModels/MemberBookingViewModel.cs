using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class MemberBookingViewModel
    {
        [Display(Name = "會員暱稱")]
        public int Nickname { get; set; }
        [Display(Name = "課程圖片")]
        public int CourseThumbnail { get; set; }
        [Display(Name = "課程名稱")]
        public string CourseName { get; set; }
        [Display(Name = "教師名稱")]
        public string TutorName { get; set; }
        [Display(Name = "課程進度")]
        public double CourseProgress { get; set; }
        [Display(Name = "預約進度")]
        public int BookedProgress { get; set; }

        [Display(Name = "最近預約日期")]
        public DateTime LatestBookingDate { get; set; }
        [Display(Name = "最近預約時間")]
        public DateTime LatestBookingTime { get; set; }
    }
}
