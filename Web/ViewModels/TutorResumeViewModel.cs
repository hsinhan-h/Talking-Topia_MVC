using Microsoft.AspNetCore.Mvc.Rendering;


namespace Web.ViewModels
{

    public class TutorResumeViewModel
    {

        public int memberId { get; set; }
        /// <summary>
        /// 大頭貼
        /// </summary>
        //[Required]
        public string HeadShotImage { get; set; }
        /// <summary>
        /// 學校名稱
        /// </summary>
        //[Required]
        public string SchoolName { get; set; }
        /// <summary>
        /// 就學始年
        /// </summary>
        //[Required(ErrorMessage = "請輸入西元年份")]
        public int StudyStartYear { get; set; }
        /// <summary>
        /// 就學結束年
        /// </summary>
        //[Required(ErrorMessage = "請輸入西元年份")]
        public int StudyEndYear { get; set; }
        /// <summary>
        /// 科系名稱
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 證照
        /// </summary>
        //[Required]
        public List<string> ProfessionalLicenseName { get; set; } = new List<string>();
        ///// <summary>
        ///// 證照Url
        ///// </summary>
        ////[Required]
        public List<string> ProfessionalLicenseUrl { get; set; } = new List<string>();
        /// <summary>
        /// 工作起始日期
        /// </summary>
        //[Required]
        public List<int> ProfessionalLicenseId { get; set; } = new List<int>();
        public List<ResumeWorkExp> WorkBackground { get; set; } = new List<ResumeWorkExp> { new ResumeWorkExp() };
        public class ResumeWorkExp
        {
            public DateOnly? WorkStartDate { get; set; }
            public DateOnly? WorkEndDate { get; set; }
            public string WorkName { get; set; }
        }
        public ApplyCourseList CourseList { get; set; } = new ApplyCourseList();
        public class ApplyCourseList
        {
            public int ApplyCourseCategoryId { get; set; }
            public int ApplySubCategoryId { get; set; }
        }

        public string WorkExperienceFile { get; set; }
        public string SelectedCategory { get; set; }
        public string SelectedSubcategory { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }

       
    }
       
}
