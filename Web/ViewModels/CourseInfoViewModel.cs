using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class CourseInfoViewModel
    {
        [Display(Name="教師頭像")]
        public string TutorHeadShotImage { get; set; }
        public string TutorFlagImage { get; set; }
        public bool IsVerifiedTutor { get; set; }
        public string CourseTitle { get; set; }
        public string CourseSubTitle { get; set; }
        public string TutorIntro { get; set; }
        public decimal TrialPriceNTD { get; set; }
        public decimal FiftyMinPriceNTD { get; set; }
        
       
    }
}
