using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class CourseManagementDto
    {
        public int CourseId { get; set; }
        public int MemberId { get; set; }
        public string Title { get; set; }
        [Display(Name = "教師頭像")]
        public string TutorHeadShotImage { get; set; }
        [Display(Name = "教師國旗圖像")]
        public string TutorFlagImage { get; set; }
        [Display(Name = "教師國籍")]
        public string NationName { get; set; }
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
        public int FinishedCoursesTotal { get; set; }
        [Display(Name = "課程評分")]
        public double CourseRatings { get; set; }
        [Display(Name = "課程評論數")]
        public int CourseReviews { get; set; }

        [Display(Name = "科目Id")]
        public int SubjectId { get; set; }
        [Display(Name = "科目名稱")]
        public string SubjectName { get; set; }
    }
}
