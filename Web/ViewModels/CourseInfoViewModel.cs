using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class CourseInfoViewModel
    {
        [Display(Name = "教師頭像")]
        public string TutorHeadShotImage { get; set; }
        [Display(Name = "教師國旗圖像")]
        public string TutorFlagImage { get; set; }
        [Display(Name = "優良教師")]
        public bool IsVerifiedTutor { get; set; }
        [Display(Name = "會說的語言")]
        public string SpokenLanguage { get; set; }
        [Display(Name = "學歷")]
        public string EducationDegree { get; set; }
        [Display(Name = "經歷")]
        public string Experience { get; set; }
        [Display(Name = "課程名稱")]
        public string CourseTitle { get; set; }
        [Display(Name = "課程副標題")]
        public string CourseSubTitle { get; set; }
        [Display(Name = "教師簡介")]
        public string TutorIntro { get; set; }
        [Display(Name = "課程介紹")]
        public string CourseIntro { get; set; }
        [Display(Name = "體驗台幣價格")]
        public decimal TrialPriceNTD { get; set; }
        [Display(Name = "25分鐘台幣價格")]
        public decimal TwentyFiveMinPriceNTD { get; set; }
        [Display(Name = "50分鐘台幣價格")]
        public decimal FiftyMinPriceNTD { get; set; }
        [Display(Name = "課程影片")]
        public string CourseVideo { get; set; }
        [Display(Name = "課程影片縮圖")]
        public string CourseVideoThumbnail { get; set; }
        [Display(Name = "課程照片")]
        public List<CourseImage> CourseImages { get; set; }
        [Display(Name = "完成課堂數")]
        public int FinishedCoursesTotal { get; set; }
        [Display(Name = "已被預約時段")]
        public List<TimeSlot> BookedTimeSlots { get; set; }
        [Display(Name = "可預約時段")]
        public List<TimeSlot> AvailableTimeSlots { get; set; }
        [Display(Name = "課程評分")]
        public double CourseRatings { get; set; }
        [Display(Name = "課程評論數")]
        public int CourseReviews { get; set; }
        [Display(Name = "評論內容")]
        public List<Review> ReviewContents { get; set; }
        [Display(Name = "關注狀態")]
        public bool FollowingStatus { get; set; }

    }

    public class CourseImage
    {
        public string ImageUrl {  get; set; }
    }

    public class TimeSlot
    {
        public DayOfWeek Weekday { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public string StartHourText { get; set; }  //string表示的時間格式
        public string EndHourText { get; set; } //string表示的時間格式
    }

    public class Review
    {
        public string ReviewContent {  get; set; }
    }

}
