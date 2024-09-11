using Microsoft.AspNetCore.Mvc.Rendering;


namespace Web.ViewModels
{

    public class TutorResumeViewModel
    {
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
        public List<string> ProfessionalLicenseName { get; set; }
        ///// <summary>
        ///// 證照Url
        ///// </summary>
        ////[Required]
        public List<string> ProfessionalLicenseUrl { get; set; }
        ///// <summary>
        ///// 語言分類
        ///// </summary>
        ////[Required]
        //public List<SelectListItem> Category { get; set; }
        /// <summary>
        /// 工作起始日期
        /// </summary>
        //[Required]
        public DateTime WorkStartDate { get; set; }
        ///// <summary>
        ///// 工作結束日期
        ///// </summary>
        ////[Required]
        public DateTime WorkEndDate { get; set; }
        ///// <summary>
        ///// 工作名稱
        ///// </summary>
        ////[Required]
        public string WorkName { get; set; }
        ///// <summary>
        ///// 工作簡述檔案
        ///// </summary>
        ////[Required(ErrorMessage = "請上傳檔案")]
        public string WorkExperienceFile { get; set; }
        public string SelectedCategory { get; set; }
        public string SelectedSubcategory { get; set; }
    }
}
