using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Web.Entities;

namespace Web.ViewModels
{
    public class TutorDataViewModel
    {
        /// <summary>
        /// 母語
        /// </summary>
        public string NativeLanguage { get; set; }
        /// <summary>
        /// 會說的語言
        /// </summary>
        public string SpokenLanguage { get; set; }
        /// <summary>
        /// 銀行帳戶
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// 銀行代號
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 學歷
        /// </summary>
        public List<Educational> EducationalBackground { get; set; }
        /// <summary>
        /// 經歷
        /// </summary>
        public List<WorkExp> WorkBackground { get; set; }
        /// <summary>
        /// 可預約的時段
        /// </summary>
        public List<AvailReservation> AvailableReservation  { get; set; }
        /// <summary>
        /// 科目類別
        /// </summary>
        public List<string> CategoryName { get; set; }
        /// <summary>
        /// 證照
        /// </summary>
        public List<LicenseData> License { get; set; }
        
    }



    public class Educational
    {
        public string SchoolName { get; set; }
        public int StudyStartYear { get; set; }
        public int StudyEndYear { get; set; }
    }
    public class WorkExp
    {
        public DateTime WorkStartDate { get; set; }
        public DateTime WorkEndDate { get; set; }
        public string WorkName { get; set; }
    }

    public class AvailReservation
    {
    
    }

    public class LicenseData 
    {
    
    }
}
