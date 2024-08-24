using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class MemberProfileViewModel
    {
        [Display(Name = "照片")]
        public string ImageUrl { get; set; }

        [Display(Name = "暱稱")]
        public string Nickname { get; set; }

        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        [Display(Name = "性別")]
        public string Gender { get; set; }

        [Display(Name = "國籍")]
        public string NationName { get; set; }

        [Display(Name = "母語")]
        public string NativeLanguage { get; set; }

        [Display(Name = "會說的語言")]
        public string SpokenLanguage { get; set; }

        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Display(Name = "名字")]
        public string FirstName { get; set; }

        [Display(Name = "姓氏")]
        public string LastName { get; set; }

        [Display(Name = "信箱")]
        public string Email { get; set; }

        [Display(Name = "電話")]
        public string Phone { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name ="課程偏好")]//複數欄位
        public List<CouseListViewModel> CousePrefer { get; set; }

        [Display(Name = "學校名稱")]
        public string SchoolName { get; set; }

        [Display(Name = "就學始年")]
        public int StudyStartYear { get; set; }

        [Display(Name = "就學迄年")]
        public int StudyEndYear { get; set; }

        [Display(Name = "科系名稱")]
        public string DepartmentName { get; set; }

        [Display(Name = "證照")]
        public string ProfessionalLicenseName { get; set; }

        [Display(Name = "工作開始年")]
        public DateTime WorkStartDate { get; set; }

        [Display(Name = "工作結束年")]
        public DateTime WorkEndDate { get; set; }

        [Display(Name = "工作簡述")]
        public string WorkExperience { get; set; }

        [Display(Name = "申請科目")]
        public string CategorytName { get; set; }

        [Display(Name = "申請狀態")]
        public string ApplyStatus { get; set; }

        [Display(Name = "教師自介")]
        public string TutorIntro { get; set; }

        [Display(Name = "可接受預約時段")]//複數欄位
        public List<ReservationTimeListViewModel> ReservationTime { get; set; }

        public class CouseListViewModel
        {
            [Display(Name = "課程種類名稱")]
            public string CategorytName { get; set; }

            [Display(Name = "科目名稱")]
            public string SubjectName { get; set; }
        }

        public class ReservationTimeListViewModel
        {
            [Display(Name = "開課星期")]
            public int Weekday { get; set; }

            [Display(Name = "開課時間")]
            public int CourseHourId { get; set; }

        }

    }
}
