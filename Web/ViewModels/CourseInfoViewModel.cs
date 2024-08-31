using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class CourseInfoListViewModel
    {
        public List<CourseInfoViewModel> CourseInfoList{ get; set; }
    }


    public class CourseInfoViewModel
    {

        public int CourseId { get; set; }
        public int MemberId { get; set; }
        public string Title { get; set; }
        [Display(Name = "教師頭像")]
        public string TutorHeadShotImage { get; set; }
        [Display(Name = "教師國旗圖像")]
        public string TutorFlagImage { get; set; }
        [Display(Name = "優良教師")]
        public bool IsVerifiedTutor { get; set; }
        
        [Display(Name = "課程名稱")]
        public string CourseTitle { get; set; }
        [Display(Name = "課程副標題")]
        public string CourseSubTitle { get; set; }
        [Display(Name = "教師簡介")]
        public string TutorIntro { get; set; }
        [Display(Name = "25分鐘單位價格")]
        public decimal TwentyFiveMinUnitPrice { get; set; }

        [Display(Name = "50分鐘單位價格")]
        public decimal FiftyMinUnitPrice { get; set; }
        

        [Display(Name = "課程影片")]
        public string CourseVideo { get; set; }
        [Display(Name = "課程影片縮圖")]
        public string CourseVideoThumbnail { get; set; }
        [Display(Name = "課程照片")]
        public List<CourseImageViewModel> CourseImages { get; set; }
        [Display(Name = "完成課堂數")]
        public int FinishedCoursesTotal { get; set; }
        [Display(Name = "已被預約時段")]  
        public List<TimeSlotViewModel> BookedTimeSlots { get; set; }
        [Display(Name = "可預約時段")]
        public List<TimeSlotViewModel> AvailableTimeSlots { get; set; }
        [Display(Name = "課程評分")]
        public double CourseRatings { get; set; }
        [Display(Name = "課程評論數")]
        public int CourseReviews { get; set; }
        
        public List<ReviewViewModel> ReviewCardList { get; set; }
        [Display(Name = "關注狀態")]
        public bool FollowingStatus { get; set; }
        /// <summary>
        /// 科目Id
        /// </summary>
        public int SubjectId {  get; set; }
        /// <summary>
        /// 科目名稱
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// 會員頭像=教師頭像
        /// </summary>
        public string HeadShotImage {  get; set; }
    }

    public class CourseImageViewModel
    {
        public string ImageUrl {  get; set; }
    }

    public class TimeSlotViewModel
    {
        public DateTime Date { get; set; }
        public int Weekday { get; set; }
        public int StartHour { get; set; }
        public string StartHourText { get; set; }  //string表示的時間格式
    }

    


    

}
