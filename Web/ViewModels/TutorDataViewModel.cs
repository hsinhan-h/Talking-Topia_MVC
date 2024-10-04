using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Web.Entities;
using static Web.Services.TutorDataservice;

namespace Web.ViewModels
{
    public class TutorDataViewModel
    {
        public int MemberId { get; set; }
        public int TutorId { get; set; }
        /// <summary>
        /// 國籍
        /// </summary>
        public int NationID { get; set; }
        /// <summary>
        /// 母語
        /// </summary>
        [Required(ErrorMessage = "母語為必填欄位")]
        public string NativeLanguage { get; set; }
        /// <summary>
        /// 會說的語言
        /// </summary>
        [Required(ErrorMessage = "會說的語言為必填欄位")]
        public string SpokenLanguage { get; set; }
        /// <summary>
        /// 銀行帳戶
        /// </summary>
        [Required(ErrorMessage = "銀行帳戶為必填欄位")]
        public string BankAccount { get; set; }
        /// <summary>
        /// 銀行代號
        /// </summary>
        [Required(ErrorMessage = "銀行代碼為必填欄位")]
        public string BankCode { get; set; }
        /// <summary>
        /// 學歷
        /// </summary>
        /// {
        public Dictionary<int, WeekdaySchedule> Schedule { get; set; }

        public List<Educational> EducationalBackground { get; set; } = new List<Educational>();
        /// <summary>
        /// 經歷
        /// </summary>
        public List<WorkExp> WorkBackground { get; set; } = new List<WorkExp>();
        /// <summary>
        /// 可預約的時段
        /// </summary>
        public List<AvailReservation> AvailableReservation { get; set; } = new List<AvailReservation>();
        /// <summary>
        /// 科目類別
        /// </summary>
        public List<CategoryData> Course { get; set; } = new List<CategoryData>();


        /// <summary>
        /// 證照
        /// </summary>
        public List<LicenseData> License { get; set; } = new List<LicenseData>();


        public CourseStatus Coursestatus { get; set; }

        public bool HasCourses
        {
            get { return Course != null && Course.Any(); }
        }

        public bool Success { get; set; }
        public string Message { get; set; }

        //public Dictionary<string, List<string>> ValidationErrors { get; set; } = new Dictionary<string, List<string>>();
    }

    public class WeekdaySchedule
    {
        public int Weekday { get; set; } // 對應的星期
        public List<int> CouseHoursId { get; set; } = new List<int>();
    }

    public class Educational
    {
        public string SchoolName { get; set; }
        public int StudyStartYear { get; set; }
        public int StudyEndYear { get; set; }
    }
    public class WorkExp
    {
        public DateOnly WorkStartDate { get; set; }
        public DateOnly WorkEndDate { get; set; }
        public string WorkName { get; set; }
    }
    public class CategoryData
    {
        public string CategoryName { get; set; }
        public string SubjectName { get; set; }
    }

    public class AvailReservation
    {
        public int? Weekday { get; set; }
        public string Coursehours { get; set; }
    }

    public class LicenseData
    {
        public string ProfessionalLicenseName { get; set; }
        public string ProfessionalLicenseUrl { get; set; }
    }
}
