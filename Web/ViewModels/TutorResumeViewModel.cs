using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace Web.ViewModels
{
    public class TutorResumeListViewModel
    {
        public List<TutorResumeViewModel> TutorResumeList { get; set; }
    }


    public class TutorResumeViewModel
    {
        /// <summary>
        /// 大頭貼
        /// </summary>
        public string HeadShotImage { get; set; }
        /// <summary>
        /// 學校名稱
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 就學始年
        /// </summary>
        public int StudyStartYear { get; set; }
        /// <summary>
        /// 就學結束年
        /// </summary>
        public int StudyEndYear { get; set; }
        /// <summary>
        /// 科系名稱
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 證照
        /// </summary>
        public List<string> ProfessionalLicenseName { get; set; }  
        /// <summary>
        /// 證照Url
        /// </summary>
        public List<string> ProfessionalLicenseUrl { get; set; } 
        /// <summary>
        /// 語言分類
        /// </summary>
        public List<SelectListItem> Category { get; set; }
        /// <summary>
        /// 工作起始日期
        /// </summary>
        public DateTime WorkStartDate { get; set; }
        /// <summary>
        /// 工作結束日期
        /// </summary>
        public DateTime WorkEndDate { get; set; }
        /// <summary>
        /// 工作名稱
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// 工作簡述檔案
        /// </summary>
        public string WorkExperienceFile { get; set; }
    }
}
